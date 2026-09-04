namespace Geometry2DLibrary.Primitives
{
    /// <summary>
    /// ベクトルを表す構造体
    /// </summary>
    /// <param name="X">X座標</param>
    /// <param name="Y">Y座標</param>
    public readonly record struct Vector2D ( double X , double Y )
    {
        /// <summary>
        /// 原点座標のベクトル
        /// </summary>
        public static readonly Vector2D Origin = new Vector2D ( 0 , 0 );

        /// <summary>
        /// 長さ
        /// </summary>
        public double Length => Math.Sqrt ( X * X + Y * Y );

        /// <summary>
        /// 長さの二乗
        /// </summary>
        public double LengthSquared => X * X + Y * Y;

        /// <summary>
        /// 長さを1に正規化したベクトルを返す
        /// </summary>
        /// <returns>長さを1としたベクトル</returns>
        public Vector2D Normalize ()
        {
            if ( Length == 0 )
            {
                return Origin;
            }

            return new ( X / Length , Y / Length );
        }

        /// <summary>
        /// 内積を計算する
        /// </summary>
        /// <param name="other">ベクトル</param>
        /// <returns>内積</returns>
        public double Dot ( Vector2D other )
            => X * other.X + Y * other.Y;

        /// <summary>
        /// 外積を計算する
        /// </summary>
        /// <param name="other">ベクトル</param>
        /// <returns>外積</returns>
        public double Cross ( Vector2D other ) => X * other.Y - Y * other.X;

        /// <summary>
        /// 90度時計回りに回転したベクトルを返す
        /// </summary>
        /// <returns>ベクトル</returns>
        public Vector2D Rotate90Clockwise () => new ( Y , -X );

        /// <summary>
        /// 90度反時計回りに回転したベクトルを返す
        /// </summary>
        /// <returns>ベクトル</returns>
        public Vector2D Rotate90CounterClockwise () => new ( -Y , X );

        /// <summary>
        /// ベクトルの加算を行う
        /// </summary>
        /// <param name="left">左辺</param>
        /// <param name="right">右辺</param>
        /// <returns>加算されたベクトル</returns>
        public static Vector2D operator + ( Vector2D left , Vector2D right ) => new ( left.X + right.X , left.Y + right.Y );

        /// <summary>
        /// ベクトルの減算を行う
        /// </summary>
        /// <param name="left">左辺</param>
        /// <param name="right">右辺</param>
        /// <returns>減算されたベクトル</returns>
        public static Vector2D operator - ( Vector2D left , Vector2D right ) => new ( left.X - right.X , left.Y - right.Y );

        /// <summary>
        /// ベクトルの乗算を行う
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="scalar"></param>
        /// <returns>乗算されたベクトル</returns>
        public static Vector2D operator * ( Vector2D vector , double scalar ) => new ( vector.X * scalar , vector.Y * scalar );

        /// <summary>
        /// ベクトルの除算を行う
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="scalar"></param>
        /// <returns>除算されたベクトル</returns>
        public static Vector2D operator / ( Vector2D vector , double scalar ) => new ( vector.X / scalar , vector.Y / scalar );

        /// <summary>
        /// 文字列に変換する
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString () => $"({X}, {Y})";
    }
}
