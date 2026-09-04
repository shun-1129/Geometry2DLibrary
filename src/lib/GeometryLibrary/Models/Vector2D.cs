namespace GeometryLibrary.Models;

/// <summary>
/// 2次元ベクターを表す不変（イミュータブル）な値型クラス。
/// <see cref="System.Numerics.Vector2"/> と同様のAPIを提供しつつ、
/// <c>float</c> の精度不足を避けるため座標値を <c>decimal</c> 型で保持する。
/// </summary>
public class Vector2D
{
    /// <summary>
    /// X座標の値を保持するフィールド。
    /// </summary>
    private readonly decimal _x;

    /// <summary>
    /// Y座標の値を保持するフィールド。
    /// </summary>
    private readonly decimal _y;

    /// <summary>
    /// X座標の値を取得するプロパティ。
    /// </summary>
    public decimal X => _x;

    /// <summary>
    /// Y座標の値を取得するプロパティ。
    /// </summary>
    public decimal Y => _y;

    /// <summary>
    /// X座標・Y座標を指定して <see cref="Vector2D"/> のインスタンスを生成する。
    /// </summary>
    /// <param name="x">X座標の値</param>
    /// <param name="y">Y座標の値</param>
    public Vector2D ( decimal x , decimal y )
    {
        _x = x;
        _y = y;
    }

    /// <summary>
    /// X, Yが共に0であるベクターを取得する。
    /// </summary>
    public static Vector2D Zero => new ( 0m , 0m );

    /// <summary>
    /// X, Yが共に1であるベクターを取得する。
    /// </summary>
    public static Vector2D One => new ( 1m , 1m );

    /// <summary>
    /// X軸方向の単位ベクターを取得する。
    /// </summary>
    public static Vector2D UnitX => new ( 1m , 0m );

    /// <summary>
    /// Y軸方向の単位ベクターを取得する。
    /// </summary>
    public static Vector2D UnitY => new ( 0m , 1m );

    /// <summary>
    /// 現在のベクターの長さ（原点からの距離）を計算する。
    /// </summary>
    /// <remarks>
    /// <c>decimal</c> 型には平方根演算が標準で存在しないため、
    /// 内部で <c>double</c> に変換して計算した結果を <c>decimal</c> に戻す。
    /// </remarks>
    /// <returns>ベクターの長さ</returns>
    public decimal Length ()
    {
        var lengthSquared = LengthSquared();
        return ( decimal ) Math.Sqrt ( ( double ) lengthSquared );
    }

    /// <summary>
    /// ベクターの長さの2乗を計算する。平方根計算を避けたい比較処理などで利用する。
    /// </summary>
    /// <returns>ベクターの長さの2乗の値</returns>
    public decimal LengthSquared ()
    {
        return ( _x * _x ) + ( _y * _y );
    }

    /// <summary>
    /// ベクターを正規化（長さを1にする）した新しい <see cref="Vector2D"/> インスタンスを返す。
    /// </summary>
    /// <returns>正規化されたベクター</returns>
    /// <exception cref="DivideByZeroException">ベクターの長さが0の場合に発生する。</exception>
    public Vector2D Normalize ()
    {
        var length = Length();
        if ( length == 0m )
        {
            throw new DivideByZeroException ( "ベクターの長さが0のため正規化できません。" );
        }

        return new Vector2D ( _x / length , _y / length );
    }

    /// <summary>
    /// 2つのベクターの内積を計算する。
    /// </summary>
    /// <param name="a">1つ目のベクター</param>
    /// <param name="b">2つ目のベクター</param>
    /// <returns>内積の値</returns>
    public static decimal Dot ( Vector2D a , Vector2D b )
    {
        return ( a.X * b.X ) + ( a.Y * b.Y );
    }

    /// <summary>
    /// 2点間の距離を計算する。
    /// </summary>
    /// <param name="a">1つ目の点</param>
    /// <param name="b">2つ目の点</param>
    /// <returns>距離</returns>
    public static decimal Distance ( Vector2D a , Vector2D b )
    {
        return ( a - b ).Length ();
    }

    /// <summary>
    /// 2点間の距離の2乗を計算する。
    /// </summary>
    /// <param name="a">1つ目の点</param>
    /// <param name="b">2つ目の点</param>
    /// <returns>距離の2乗</returns>
    public static decimal DistanceSquared ( Vector2D a , Vector2D b )
    {
        return ( a - b ).LengthSquared ();
    }

    /// <summary>
    /// 他のベクターと値が等しいかどうかを判定する。
    /// </summary>
    /// <param name="other">比較対象のベクター</param>
    /// <returns>値が等しい場合は<c>true</c>、そうでない場合は<c>false</c></returns>
    public bool Equals ( Vector2D? other )
    {
        if ( other is null )
        {
            return false;
        }

        return _x == other._x && _y == other._y;
    }

    /// <summary>
    /// 他のオブジェクトと値が等しいかどうかを判定する。
    /// </summary>
    /// <param name="obj">比較対象のオブジェクト</param>
    /// <returns>値が等しい場合は<c>true</c>、そうでない場合は<c>false</c></returns>
    public override bool Equals ( object? obj )
    {
        return Equals ( obj as Vector2D );
    }

    /// <summary>
    /// ハッシュコードを取得する。
    /// </summary>
    /// <returns>ハッシュコード</returns>
    public override int GetHashCode ()
    {
        return HashCode.Combine ( _x , _y );
    }

    /// <summary>
    /// ベクターの文字列表現を取得する。
    /// </summary>
    /// <returns>ベクターの文字列表現</returns>
    public override string ToString ()
    {
        return $"({_x}, {_y})";
    }

    /// <summary>
    /// ベクターの加算を行う。
    /// </summary>
    /// <param name="a">1つ目のベクター</param>
    /// <param name="b">2つ目のベクター</param>
    /// <returns>加算結果のベクター</returns>
    public static Vector2D operator + ( Vector2D a , Vector2D b )
    {
        return new Vector2D ( a.X + b.X , a.Y + b.Y );
    }

    /// <summary>
    /// ベクターの減算を行う。
    /// </summary>
    /// <param name="a">1つ目のベクター</param>
    /// <param name="b">2つ目のベクター</param>
    /// <returns>減算結果のベクター</returns>
    public static Vector2D operator - ( Vector2D a , Vector2D b )
    {
        return new Vector2D ( a.X - b.X , a.Y - b.Y );
    }

    /// <summary>
    /// ベクターとスカラー値の乗算を行う。
    /// </summary>
    /// <param name="a">対象のベクター</param>
    /// <param name="scalar">乗算するスカラー値</param>
    /// <returns>乗算結果のベクター</returns>
    public static Vector2D operator * ( Vector2D a , decimal scalar )
    {
        return new Vector2D ( a.X * scalar , a.Y * scalar );
    }

    /// <summary>
    /// ベクターとスカラー値の除算を行う。
    /// </summary>
    /// <param name="a">対象のベクター</param>
    /// <param name="scalar">除算するスカラー値</param>
    /// <returns>除算結果のベクター</returns>
    /// <exception cref="DivideByZeroException">スカラー値が0の場合に発生する。</exception>
    public static Vector2D operator / ( Vector2D a , decimal scalar )
    {
        if ( scalar == 0m )
        {
            throw new DivideByZeroException ( "スカラー値が0のため除算できません。" );
        }

        return new Vector2D ( a.X / scalar , a.Y / scalar );
    }

    /// <summary>
    /// ベクターの等価比較を行う。
    /// </summary>
    /// <param name="a">1つ目のベクター</param>
    /// <param name="b">2つ目のベクター</param>
    /// <returns>値が等しい場合は<c>true</c>、そうでない場合は<c>false</c></returns>
    public static bool operator == ( Vector2D? a , Vector2D? b )
    {
        if ( a is null )
        {
            return b is null;
        }

        return a.Equals ( b );
    }

    /// <summary>
    /// ベクターの非等価比較を行う。
    /// </summary>
    /// <param name="a">1つ目のベクター</param>
    /// <param name="b">2つ目のベクター</param>
    /// <returns>値が異なる場合は<c>true</c>、そうでない場合は<c>false</c></returns>
    public static bool operator != ( Vector2D? a , Vector2D? b )
    {
        return !( a == b );
    }
}
