# Vector2D 設計書

## 基本情報

| 項目 | 内容 |
| --- | --- |
| クラス名 | `Vector2D` |
| 名前空間 | `Geometry2DLibrary.Primitives` |
| 種別 | `readonly record struct` |
| 目的 | 2 次元空間におけるベクトルを表現し、基本的なベクトル演算を提供する。 |
| 作成日 | 2026-08-01 |

## 概要

`Vector2D` は、倍精度浮動小数点数の X 成分および Y 成分からなる不変の 2 次元ベクトルです。
record struct として定義されるため、値による比較を利用できます。長さ、正規化、内積、外積、
90 度回転、および四則演算子を提供します。

```text
Vector2D
├─ X, Y                    : ベクトル成分
├─ Length, LengthSquared   : 大きさ
├─ Normalize               : 単位ベクトル化
├─ Dot, Cross              : ベクトル演算
└─ Rotate90...             : 90 度回転
```

## 依存関係

| 依存先 | 用途 |
| --- | --- |
| .NET `System.Math` | `Length` の平方根計算に使用する。 |
| `System.Double` | X 成分、Y 成分、およびスカラー値の表現に使用する。 |

外部ライブラリには依存しません。

## プロパティおよび属性

| 名前 | 型 | 説明 |
| --- | --- | --- |
| `X` | `double` | X 方向の成分。コンストラクターで設定され、変更できない。 |
| `Y` | `double` | Y 方向の成分。コンストラクターで設定され、変更できない。 |
| `Origin` | `static readonly Vector2D` | `(0, 0)` を表すゼロベクトル。 |
| `Length` | `double` | `sqrt(X² + Y²)` で求めるベクトルの長さ。 |
| `LengthSquared` | `double` | `X² + Y²` で求める長さの二乗。平方根計算を避けたい比較処理に適する。 |

## メソッドおよび演算子

| 名前 | 戻り値 | 説明 |
| --- | --- | --- |
| `Normalize()` | `Vector2D` | 長さが 1 のベクトルを返す。ゼロベクトルに対しては `Origin` を返す。 |
| `Dot(Vector2D other)` | `double` | `X * other.X + Y * other.Y` を計算する。ベクトルの射影や角度判定に使用する。 |
| `Cross(Vector2D other)` | `double` | `X * other.Y - Y * other.X` を計算する。符号により他方のベクトルとの回転方向を判定できる。 |
| `Rotate90Clockwise()` | `Vector2D` | `(X, Y)` を `(Y, -X)` に変換し、90 度時計回りに回転したベクトルを返す。 |
| `Rotate90CounterClockwise()` | `Vector2D` | `(X, Y)` を `(-Y, X)` に変換し、90 度反時計回りに回転したベクトルを返す。 |
| `operator +(Vector2D left, Vector2D right)` | `Vector2D` | 成分ごとの加算を行う。 |
| `operator -(Vector2D left, Vector2D right)` | `Vector2D` | 成分ごとの減算を行う。 |
| `operator *(Vector2D vector, double scalar)` | `Vector2D` | 各成分にスカラーを乗算する。 |
| `operator /(Vector2D vector, double scalar)` | `Vector2D` | 各成分をスカラーで除算する。 |
| `ToString()` | `string` | `(X, Y)` 形式の文字列を返す。 |

## 使用例

```csharp
using Geometry2DLibrary.Primitives;

Vector2D direction = new ( 3 , 4 );

double length = direction.Length;                 // 5
Vector2D unitDirection = direction.Normalize ();  // (0.6, 0.8)
Vector2D perpendicular = direction.Rotate90Clockwise (); // (4, -3)

Vector2D offset = new ( 1 , -2 );
Vector2D moved = direction + offset;              // (4, 2)
double dotProduct = direction.Dot ( offset );     // -5
double crossProduct = direction.Cross ( offset ); // -10
```

## 注意事項および制約条件

- `double` 演算のため、丸め誤差が発生する可能性があります。等価性やゼロ判定では、用途に応じた許容誤差を考慮してください。
- `Normalize()` は長さが厳密に `0` の場合だけゼロベクトルを返します。極めて短いベクトルをゼロとして扱う必要がある場合は、呼び出し側で `LengthSquared` と許容誤差を比較してください。
- `operator /` はスカラー値が `0` の場合、`double` の規則に従って無限大または `NaN` を返します。例外は送出しません。
- `NaN` または無限大の成分を指定した場合、各演算結果にも伝播します。入力値の妥当性確認が必要な境界では、呼び出し側で検証してください。
- `LengthSquared` は `Length` より高速ですが、成分が非常に大きい場合は乗算時に無限大へオーバーフローする可能性があります。

## パフォーマンスおよびセキュリティ

- 不変の値型であり、ヒープ割り当てを抑えながらベクトルを扱えます。ただし、大量のボックス化やインターフェース経由の利用は割り当てを生む可能性があります。
- 距離の大小比較には平方根を伴わない `LengthSquared` を使用してください。
- 外部入力をベクトル成分として受け取る場合は、`NaN`、無限大、および想定外に大きい値を検証し、後続の幾何計算や表示処理への影響を防いでください。

## テストおよびデバッグ観点

| 観点 | 確認内容 |
| --- | --- |
| 長さ | `(3, 4)` の `Length` が `5`、`LengthSquared` が `25` となること。 |
| 正規化 | `(3, 4)` の正規化結果が `(0.6, 0.8)` となり、ゼロベクトルでは `Origin` となること。 |
| 内積・外積 | 直交するベクトルの内積が `0` となり、外積の符号で回転方向を判定できること。 |
| 回転 | 時計回りと反時計回りの回転結果が期待する成分となること。 |
| 演算子 | 加算、減算、スカラー乗算、スカラー除算が各成分に正しく適用されること。 |
| 境界値 | ゼロ、負数、非常に大きい値、`NaN`、無限大を含む入力時の挙動を確認すること。 |

## 変更履歴

| 日付 | 内容 |
| --- | --- |
| 2026-08-01 | 初版作成 |
