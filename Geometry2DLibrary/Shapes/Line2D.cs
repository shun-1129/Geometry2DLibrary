using Geometry2DLibrary.Primitives;

namespace Geometry2DLibrary.Shapes
{
    /// <summary>
    /// 2次元の直線を表す構造体
    /// </summary>
    public readonly record struct Line2D
    {
        /// <summary>
        /// 直線上の始点を取得します。
        /// </summary>
        public Point2D Start { get; init; }

        /// <summary>
        /// 直線上の終点を取得します。
        /// </summary>
        public Point2D End { get; init; }

        /// <summary>
        /// 直線の方向ベクトルを取得します。
        /// </summary>
        public Vector2D Direction => End - Start;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// Line2Dを初期化する際に、開始点と終了点が同じ場合は例外をスローします。
        /// </remarks>
        /// <param name="start">開始点</param>
        /// <param name="end">終了点</param>
        /// <exception cref="ArgumentException">開始点と終了点が同じ場合</exception>
        public Line2D ( Point2D start , Point2D end )
        {
            if ( start == end )
            {
                throw new ArgumentException ( "開始点と終了点は異なる必要があります。" );
            }

            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// 指定された距離における直線上のポイントを取得します。
        /// </summary>
        /// <param name="distance">距離</param>
        /// <returns>ポイント</returns>
        public Point2D PointAt ( double distance )
        {
            Vector2D dir = Direction.Normalize ();
            return Start + dir * distance;
        }

        /// <summary>
        /// パラメータtにおける直線上のポイントを取得します。
        /// </summary>
        /// <remarks>
        /// t=0でStart、t=1でEndとなります。
        /// </remarks>
        /// <param name="t">パラメータ</param>
        /// <returns></returns>
        public Point2D PointAtParameter ( double t ) => Start + Direction * t;
    }
}
