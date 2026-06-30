namespace Geometry2DLibrary.Core
{
    /// <summary>
    /// ポイントを表す構造体
    /// </summary>
    public readonly record struct Point2D ( double X , double Y )
    {
        /// <summary>
        /// 原点座標のポイント
        /// </summary>
        public static readonly Point2D Origin = new Point2D ( 0 , 0 );

        /// <summary>
        /// 直線距離を計算する
        /// </summary>
        /// <param name="other">ポイント</param>
        /// <returns>直線距離</returns>
        public double DistanceTo ( Point2D other )
        {
            double dx = other.X - X;
            double dy = other.Y - Y;

            return Math.Sqrt ( dx * dx + dy * dy );
        }

        /// <summary>
        /// 距離の二乗を計算する
        /// </summary>
        /// <param name="other">ポイント</param>
        /// <returns>距離の二乗</returns>
        public double DistanceSquaredTo ( Point2D other )
        {
            double dx = other.X - X;
            double dy = other.Y - Y;

            return dx * dx + dy * dy;
        }

        /// <summary>
        /// ベクトルに変換する
        /// </summary>
        /// <returns>ベクトル</returns>
        public Vector2D ToVector () => new ( X , Y );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Point2D operator + ( Point2D point , Vector2D vector )
            => new ( point.X + vector.X , point.Y + vector.Y );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Point2D operator - ( Point2D point , Vector2D vector )
            => new ( point.X - vector.X , point.Y - vector.Y );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2D operator - ( Point2D left , Point2D right )
            => new ( left.X - right.X , left.Y - right.Y );

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString ()
            => $"({X}, {Y})";
    }
}
