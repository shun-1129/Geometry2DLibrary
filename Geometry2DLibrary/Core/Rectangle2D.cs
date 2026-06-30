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
        /// 中心座標
        /// </summary>
        public Point2D Center
            => new ( ( MinX + MaxX ) / 2 ,
                   ( MinY + MaxY ) / 2 );

        /// <summary>
        /// ポイントが矩形内に含まれるかどうかを判定する
        /// </summary>
        /// <param name="point">ポイント</param>
        /// <returns>
        /// 存在する：<see langword="true"/><br/>
        /// 存在しない：<see langword="false"/>
        /// </returns>
        public bool Contains ( Point2D point )
        {
            return point.X >= MinX &&
                   point.X <= MaxX &&
                   point.Y >= MinY &&
                   point.Y <= MaxY;
        }

        /// <summary>
        /// 矩形同士が交差するかどうかを判定する
        /// </summary>
        /// <param name="other">矩形</param>
        /// <returns>
        /// 交差する：<see langword="true"/><br/>
        /// 交差しない：<see langword="false"/>
        /// </returns>
        public bool Intersects ( Rectangle2D other )
        {
            return !( other.MinX > MaxX ||
                     other.MaxX < MinX ||
                     other.MinY > MaxY ||
                     other.MaxY < MinY );
        }

        /// <summary>
        /// 矩形を指定した値だけ拡張する
        /// </summary>
        /// <param name="value">拡張する範囲</param>
        /// <returns>拡張された矩形</returns>
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
