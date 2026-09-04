using Geometry2DLibrary.Primitives;

namespace Geometry2DLibrary.Shapes
{
    /// <summary>
    /// 2次元の線分を表す構造体
    /// </summary>
    public readonly record struct Segment2D
    {
        /// <summary>
        /// 開始点を取得します。
        /// </summary>
        public Point2D Start { get; init; }

        /// <summary>
        /// 終了点を取得します。
        /// </summary>
        public Point2D End { get; init; }

        /// <summary>
        /// 直接の方向ベクトルを取得します。
        /// </summary>
        public Vector2D Direction => End - Start;

        /// <summary>
        /// ベクトルの長さを取得します。
        /// </summary>
        public double Length => Direction.Length;

        /// <summary>
        /// ベクトルの長さの二乗を取得します。
        /// </summary>
        public double LengthSquared => Direction.LengthSquared;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="start">開始点</param>
        /// <param name="end">終了点</param>
        public Segment2D ( Point2D start , Point2D end )
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// 線分の中点を取得します。
        /// </summary>
        public Point2D MidPoint => new ( ( Start.X + End.X ) * 0.5 , ( Start.Y + End.Y ) * 0.5 );

        /// <summary>
        /// 無限直線へ変換します。
        /// </summary>
        public Line2D ToLine () => new Line2D ( Start , End );

        /// <summary>
        /// パラメータtの位置を取得します。
        /// </summary>
        /// <remarks>
        /// t=0でStart、t=1でEndです。
        /// </remarks>
        public Point2D PointAt ( double t ) => Start + Direction * t;
    }
}
