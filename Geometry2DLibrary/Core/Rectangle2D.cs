namespace Geometry2DLibrary.Core
{
    public readonly record struct Rectangle2D (
        double MinX ,
        double MinY ,
        double MaxX ,
        double MaxY )
    {
        /// <summary>
        /// 幅
        /// </summary>
        public double Width => MaxX - MinX;

        /// <summary>
        /// 高さ
        /// </summary>
        public double Height => MaxY - MinY;

        /// <summary>
        /// 中心
        /// </summary>
        public Point2D Center
            => new ( ( MinX + MaxX ) / 2 ,
                   ( MinY + MaxY ) / 2 );

        public bool Contains ( Point2D point )
        {
            return point.X >= MinX &&
                   point.X <= MaxX &&
                   point.Y >= MinY &&
                   point.Y <= MaxY;
        }

        public bool Intersects ( Rectangle2D other )
        {
            return !( other.MinX > MaxX ||
                     other.MaxX < MinX ||
                     other.MinY > MaxY ||
                     other.MaxY < MinY );
        }

        public Rectangle2D Inflate ( double value )
        {
            return new (
                MinX - value ,
                MinY - value ,
                MaxX + value ,
                MaxY + value );
        }

        /// <summary>
        /// 文字列に変換する
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString () => $"({MinX}, {MinY}) - ({MaxX}, {MaxY})";
    }
}
