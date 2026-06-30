namespace Geometry2DLibrary.Core
{
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

        public Vector2D Normalize ()
        {
            if ( Length == 0 )
            {
                return Origin;
            }

            return new ( X / Length , Y / Length );
        }

        public double Dot ( Vector2D other )
            => X * other.X + Y * other.Y;

        public double Cross ( Vector2D other )
            => X * other.Y - Y * other.X;

        public Vector2D Rotate90Clockwise ()
            => new ( Y , -X );

        public Vector2D Rotate90CounterClockwise ()
            => new ( -Y , X );

        public static Vector2D operator + ( Vector2D left , Vector2D right )
            => new ( left.X + right.X , left.Y + right.Y );

        public static Vector2D operator - ( Vector2D left , Vector2D right )
            => new ( left.X - right.X , left.Y - right.Y );

        public static Vector2D operator * ( Vector2D vector , double scalar )
            => new ( vector.X * scalar , vector.Y * scalar );

        public static Vector2D operator / ( Vector2D vector , double scalar )
            => new ( vector.X / scalar , vector.Y / scalar );

        /// <summary>
        /// 文字列に変換する
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString () => $"({X}, {Y})";
    }
}
