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
        /// ポイントとベクトルの加算を行う
        /// </summary>
        /// <param name="point">ポイント</param>
        /// <param name="vector">ベクトル</param>
        /// <returns>加算されたポイント</returns>
        public static Point2D operator + ( Point2D point , Vector2D vector )
            => new ( point.X + vector.X , point.Y + vector.Y );

        /// <summary>
        /// ポイントとベクトルの減算を行う
        /// </summary>
        /// <param name="point">ポイント</param>
        /// <param name="vector">ベクトル</param>
        /// <returns>減算されたポイント</returns>
        public static Point2D operator - ( Point2D point , Vector2D vector )
            => new ( point.X - vector.X , point.Y - vector.Y );

        /// <summary>
        /// ポイントを減算してベクトルを返す
        /// </summary>
        /// <param name="left">左辺</param>
        /// <param name="right">右辺</param>
        /// <returns>ベクトル</returns>
        public static Vector2D operator - ( Point2D left , Point2D right )
            => new ( left.X - right.X , left.Y - right.Y );

        /// <summary>
        /// 文字列に変換する
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString () => $"({X}, {Y})";
    }
}
