printfn "%A" [ "Hello, "; "World!" ]
// -

// ### display
// display の表示を確認します。

// ### 注意
// これの生成元である fsx 上では定義されておらずエラーになるので、コメントアウトしてあります。
// 表示を見たければコメントアウトを外して .NET notebook 上で実行してみてください。
// ### display() のカスタムフォーマッター
// 素直に表示させると強烈に見づらい表示になることがあります。
// カスタムフォーマッターがあるので、必要ならそちらで確認してください。
// ここで詳しくは書きません。

// +
//display ["Hello, "; "World!"]
printfn "%A" [ "Hello, "; "World!" ]
// -

// ## パッケージ・ライブラリ・スクリプトのインポート

// ### F# 4 時点
// paket でインストールし、次のようなシンタックスで読み込めます。
// ディスク上に既にある場合は次のようなシンタックスを使います。
//```fsharp
//#r "<path to .dll>"
//```
//スクリプトファイルは次のように読み込みます。
//```fsharp
//#load "<path to .fsx file>"
//// 例
//// #load "some-fsharp-script-file.fsx"
//```
// 競プロなど素の F# で十分な局面でほとんど使わないので、ここではこれ以上詳しく紹介しません。

// ### F# 5 以降の機能
// 次のようなシンタックスで NuGet からロードできるとアナウンスされています。
// ```fsharp
// #r "nuget:<package name>[,<version=package version>]"
//// 例
//// #r "nuget:FSharp.Data"
// ```
// バージョンを書かない場合は最新版がロードされます。

// ## Introduction to F# #

// ### F# の基礎 #

// #### F# の関数
// F# の一番基本的な要素は関数で、関数はモジュール配下に置きます。
// `let` で定義します。
// 関数呼び出しで括弧はいりません。
// このあたりの構文的な特徴が関数合成のやりやすさを生み出しています。
// 使っているうちに癖になる部分です。
// 慣れるまでは変な気分がするかもしれませんが、時間をかけて慣れることに大きな意味があります。

// +
let sampleFunction x = 2 * x * x - 5 * x + 3
sampleFunction 5 |> printfn "%A"
// -

// #### 関数合成
// 関数合成は `>>` または `<<` でできます。
// `<<` は数学と同じ向きの関数合成で、`>>` は数学と逆向きです。
// 詳しくはコードを見てください。
// おそらく `>>` の方が直観的な書き方です。

// +
module Composition =
    let negate x = -x
    let square x = x * x
    let print x = printfn "数は %d" x

    let squareNegateThenPrint1 = print << negate << square

    let squareNegateThenPrint2 = square >> negate >> print

Composition.squareNegateThenPrint1 5
Composition.squareNegateThenPrint2 5
// -

// #### パイプライン `|>`, `<|`
// 上の関数合成は直接関数を作ります。
// パイプラインは値を生みます。
// Unix のパイプラインと同じように考えてください。
// やはり例を見ると早いです。
// 特に `|>` は Unix でパイプラインを使うときと同じように書けるので、かなり使いやすい演算子です。
// これが使いたいがために F# の勉強をはじめたといっても過言ではないほどです。

// +
module PipeLine =
    let negate x = -x
    let square x = x * x
    let print x = printfn "数は %d" x
    let squareNegateThenPrint x = x |> square |> negate |> print

PipeLine.squareNegateThenPrint 5
// -

// #### ミュータブルとイミュータブル
// `let` キーワードで指定するのは標準で不変（イミュータブル）です。
// 可変（ミュータブル）にしたい場合は let mutable と書きます。
module Immutability =
    // let で値をイミュータブルに束縛する
    // コメントアウトを外すとコンパイルエラーになる：すでに束縛した number に値を割り当てられない
    let number = 2
    // let number = 3

    // ミュータブルな束縛。
    let mutable otherNumber = 2
    printfn "'otherNumber' is %d" otherNumber

    // ミュータブルな変数の値を変えるときは <- を使う。
    otherNumber <- otherNumber + 1
    printfn "'otherNumber' changed to be %d" otherNumber
// +

// -

// #### 算数
// 簡単な算数も紹介しましょう。
// `printfn` はなくても Jupyter のセル上では計算結果を出してくれます。
// ここでは `|>` を使いたいのと数値表示法のチェック用にわざとつけています。

// +
(12 / 4 + 5 + 7) * 4 - 18 |> printfn "%A"
// -

// #### 数のリストを生成
// 出力すると分かるように、リストはカンマではなくセミコロン区切りで定義します。
// OCaml 流です。
// 上に書いた通り、表示には `display` を使うといいでしょう。
// `display` では鬱陶しいこともあるので `printfn "%A"` も併用します。

// +
[ 0 .. 10 ] |> printfn "%A"
// -

// #### スライス

// +
[ 0 .. 10 ].[2..5] |> printfn "%A" // [2; 3; 4; 5]
// -

// #### 文字列
// 文字はシングルクオート、文字列はダブルクオートで、
// 結合演算子は `+` です。

// +
let s = 'h'
s |> printfn "%c"

let s1 = "Hello"
let s2 = "World"

s1 + ", " + s2 + "!" |> printfn "%A"
// -

// ダブルクオートを含む文字列を使いたいときは 3 重のダブルクオートを使うといいでしょう。

// +
let s3 =
    """A triple-quoted string can contain quotes "like this" anywhere within it"""

s3 |> printfn "%s"
// -

// 逐語的リテラル（verbatim string literal）には `@` を使います。
// これは「`\`、`\n`、`\t`」のようなエスケープ文字を無視します。

// +
let s4 = @"C:\Program Files\"
s4 |> printfn "%s"
// -

// #### ブール値

// +
module Booleans =
    // ブール値は true または false
    let boolean1 = true
    let boolean2 = false

    // ブール値に対する演算子：not, &&, ||
    let boolean3 = not boolean1 && (boolean2 || false)

    // ブール値は '%b' でプリントできる。これは型安全。
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3
// # F# の基礎
// 本題に入る前に F# の基本的な機能について簡単に紹介します。

// ## 注意
// このファイルは fsx ファイルを jupytext に変換して作っています。
// 初めから JupyterLab で実行しているわけではないので、
// 必ずしも JupyterLab 向けのベストプラクティスを紹介するわけではありません。
// ご注意ください。

// ## .NET notebook での出力
// いろいろプログラムを書いても出力できないとデバッグもしづらいので、
// いくつかサンプルを紹介します。
//
// .NET notebook については display() を使うのがいいようですが、
// まずは display() の前に F# 標準の printfn "%A" を紹介します。

// ### printfn
// `printfn "%A" var` とすれば `var` がどんな型でもだいたい表示できます。
// `"%A"` はもっと型を精密に指定できます。
// 詳しいことは調べてみてください。

// +
// -

// #### タプル

// +
open System

(1, "fred", Math.PI) |> printfn "%A"
// -

// パフォーマンスを出したいときは struct を使うといいようです。

// +
open System

struct (1, Math.PI) |> printfn "%A"
// -

// #### リスト
// すでに紹介済みですが再掲します。

// +
[ 0; 1; 2; 3 ] |> printfn "%A"
// -

// `Seq` や `Array` でも役に立つのでリスト内包表記を紹介しておきます。

// +
open System

let thisYear = DateTime.Now.Year

let fridays: string list =
    [ for month in 1 .. 10 do
        for day in 1 .. DateTime.DaysInMonth(thisYear, month) do
            let date = DateTime(thisYear, month, day)
            if date.DayOfWeek = DayOfWeek.Friday then yield date.ToShortDateString() ]

// 今年の金曜日の最初の 5 つ分の金曜日を取る
//fridays |> List.take 5 |> List.map (printfn "%A")
//printfn ""
//fridays.[..4] |> List.map (printfn "%s")
// -

// #### 配列
// リストと配列の違いは、配列の方が内部が可変（mutable）であること、配列の方が高速なことです。
// リストは `[ 0 .. 10 ]` で、配列は `[| 0 .. 10 |]` です。
// リストも配列も要素の区切り文字はカンマではなくセミコロンです。
// 慣れるまでついついカンマにしてしまうでしょう：カンマで区切るとタプルのリスト・配列になってしまいます。

// +
[| 1; 2; 3; 4 |] |> printfn "%A"
// -

// リストと同じくスライスが使えます。
// それ以外にも List や Seq と共通のメソッド・モジュールの関数も多いので、どれか 1 つを覚えると芋づる式に他も使えるようになります。

// +
let firstTwoHundred = [| 1 .. 200 |]

firstTwoHundred.[197..]
|> Array.filter (fun x -> x % 3 = 0)
|> Array.sumBy (fun x -> x * x)
// -

// #### 単位（Unit of Measure）
// F# のコアライブラリで多くの SI 単位系と単位の換算を定義しています。
// 次のページを参考にするといいでしょう。
//
// - [Microsoft.FSharp.Data.UnitSystems.SI Namespace (F#)](https://msdn.microsoft.com/visualfsharpdocs/conceptual/microsoft.fsharp.data.unitsystems.si-namespace-%5bfsharp%5d)
// +
module UnitsOfMeasure =
    // First, open a collection of common unit names
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Define a unitized constant
    let sampleValue1 = 1600.0<meter>

    // 新しい単位の型を定義
    [<Measure>]
    type mile =
        // マイルをメーターに変換
        static member asMeter = 1609.34<meter/mile>

    /// Define a unitized constant
    let sampleValue2 = 500.0<mile>

    /// Compute  metric-system constant
    let sampleValue3 = sampleValue2 * mile.asMeter

    printfn "After a %f race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3
// -

// ### 型
// 型についても簡単にまとめます。

// #### レコード
// 色々なデータをひとまとめにするのに使われます。 `.` （ドット）でラベルにアクセスできます。

// +
type ContactCard =
    { Name: string
      Phone: string
      ZipCode: string }

let alf =
    { Name = "Alf"
      Phone = "(555) 555-5555"
      ZipCode = "90210" }

alf.Phone |> printfn "%s"
// -

// 配列は比較可能で、等号成立判定もできます。

// +
// ContactCard は上のセルと同じ
let paul =
    { Name = "Paul"
      Phone = "(555) 555-5555"
      ZipCode = "90210" }

let ralph =
    { Name = "Ralph"
      Phone = "(123) 456-7890"
      ZipCode = "90210" }

paul = ralph |> printfn "%b"
// -

// #### 判別共用体（discriminated union）
// 英語だとよく DU と書くそうです。 単なる OR 型の型定義です。
// パターンマッチでよく使います。
// 非常に便利です。

// +
type Shape =
    | Rectangle of width: float * length: float
    | Circle of radius: float
    | Prism of width: float * height: float * faces: int

let rect = Rectangle(length = 1.3, width = 10.0)
let circ = Circle(1.0)

let prism =
    Prism(width = 5.0, height = 2.0, faces = 3)

prism |> printfn "%A"
// -

// #### パターンマッチ
// `height` 関数の `match hoge with` の部分です。

// +
let height shape =
    match shape with
    | Rectangle(width = h) -> h
    | Circle(radius = r) -> 2.0 * r
    | Prism(height = h) -> h

let rectHeight = height rect
let circHeight = height circ
let prismHeight = height prism

printfn "rect is %0.1f, circ is %0.1f, and prism is %0.1f" rectHeight circHeight prismHeight
// -

// +
// x が n の倍数かどうか
let isPrimeMultiple n x = x = n || x % n <> 0

// リストを再帰的に処理する
let rec removeMultiples ns xs =
    match ns with
    | [] -> xs
    | head :: tail ->
        xs
        |> List.filter (isPrimeMultiple head)
        |> removeMultiples tail

// n までの素数のリストを作る
let getPrimesUpTo n =
    let max = float n |> sqrt |> int
    removeMultiples [ 2 .. max ] [ 1 .. n ]

// 25 までの素数を取得する
getPrimesUpTo 25 |> printfn "%A"
// -

// #### Option
// これも DU です。Some と None があります。
// 最近のいろいろな言語に取り入れられています。
// エラー処理でよく使われます。

// +
let keepIfPositive a = if a > 0 then Some a else None

keepIfPositive 12 |> printfn "%A"
// -

// +
let rec tryFindMatch predicate lst =
    match lst with
    | [] -> None
    | head :: tail -> if predicate head then Some head else tryFindMatch predicate tail

// 100 以上の数なら True
let greaterThan100 x: bool = x > 100

tryFindMatch greaterThan100 [ 25; 50; 100; 150; 200 ]
// -

// #### アクティブパターン
// これもパターンマッチでよくお世話になります。

// +
open System

// パターンマッチの省略構成。
// 部分適用を使いたいときに便利。
let private parseHelper f =
    f
    >> function
    | (true, item) -> Some item
    | (false, _) -> None

//let parseDateTimeOffset input = parseHelper DateTimeOffset.TryParse input
let parseDateTimeOffset: string -> DateTimeOffset option = parseHelper DateTimeOffset.TryParse

let result = parseDateTimeOffset "1970-01-01"

match result with
| Some dto -> printfn "It parsed!"
| None -> printfn "It didn't parse!"

// パースに便利なヘルパー関数
let parseInt: string -> int option = parseHelper Int32.TryParse
let parseDouble: string -> double option = parseHelper Double.TryParse
let parseTimeSpan: string -> TimeSpan option = parseHelper TimeSpan.TryParse

let (|Int|_|) = parseInt
let (|Double|_|) = parseDouble
let (|Date|_|) = parseDateTimeOffset
let (|TimeSpan|_|) = parseTimeSpan

// `function` キーワードを通じたパターンマッチ
let printParseResult =
    function
    | Int x -> printfn "%d" x
    | Double x -> printfn "%f" x
    | Date d -> printfn "%s" (d.ToString())
    | TimeSpan t -> printfn "%s" (t.ToString())
    | _ -> printfn "Nothing was parse-able!"

// printer をいろいろな値でパースする
printParseResult "12"
printParseResult "12.045"
printParseResult "12/28/2016"
printParseResult "9:01PM"

printParseResult "banana!"
// -

// ## 補足

// ### オブジェクト指向としての側面
// F# はオブジェクト指向言語としての側面もあり、
// F# は .NET の[クラス](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/classes)・[インターフェース](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/interfaces)・[抽象クラス](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/abstract-classes)・[継承](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/inheritance)などをサポートしています。
// 実際にこれらを使うことはよくありますし、F# プログラムに必要不可欠でさえありますが、
// 自分でプログラムを書くときもモジュールと型・関数にとどめ、オブジェクト指向の要素は使わないようにした方がいいという指針があります。
// ここでもオブジェクト指向の要素は特に紹介しません。

// ### 関数プログラミング言語としての側面
// もともと OCaml を強く参考にしている言語です。
// ここでは関数プログラミングのごくごく基本的な考え方を簡単に紹介するにとどめます。
// むしろ実装のなかで体感してもらうのが目的です。

// #### ポイント
// 関数型プログラミングは、関数と不変データの使用を重視するプログラミングのスタイルのことです。
//
// - 関数を主に使う
// - 文の代わりに式を使う
// - 変数よりもイミュータブルな値を使う
// - 命令プログラミングよりも宣言的プログラミング

// #### 基本的な用語
// 次の説明だけを見ても何もわからないでしょう。
// まずはこういう言葉があり、こうした概念が大事になることだけ把握しておいてください。
//
// - 関数 - 指定した入力から出力を生成する構成要素。ある集合を別の集合へうつす。
// - 式 - 式は値を生成するコード要素。値はバインドされるかまたは明示的に無視される。
//   式は関数呼び出しで置き換えられる。
// - 純粋性 - 純粋性とは同じ引数に対して戻り値は常に同じで、その評価には副作用がないと関数の性質。
//   純粋関数はその引数にだけ依存する。
// - 参照透過性 - 参照透過性はプログラムの動作に影響を与えずにその出力を交換できる式の性質。
// - 不変性 - 不変性は値を変更できないこと。変数と比較する。

// #### 高階関数
// 次のような特性を持つ関数です。
//
// - 引数として関数を受け取り、関数呼び出しの結果値として関数を返す。
//
// 具体例を見ないことにはイメージがつかないでしょう。
// 今後、何度も出てくるとは思いますが、ここでも例を紹介します。

// +
// f に関数を割り当てる想定
let applyIt: (int32 -> int32) -> int32 -> int32 = fun f n -> f n
// 数を 2 乗する関数
let square n = n * n

applyIt square 10 |> printfn "%d" // 10 * 10 = 100 になる
// -

// 上で applyIt には square という関数を与えています。
// こうした「関数を変数とする関数」が高階関数です。
// 次の例は map です。

// +
// map でリスト全体に関数適用
[ 1; 2; 3; 4; 5; 6; 7 ]
|> List.map (fun n -> n * n)
|> printfn "%A" // [1; 4; 9; 16; 25; 36; 49]

// map でリスト各要素の偶奇判定
[ 1; 2; 3; 4; 5; 6; 7 ]
|> List.map (fun n -> n % 2 = 0)
|> printfn "%A" // [false; true; false; true; false; true; false]
// -
