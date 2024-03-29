// # 計算機科学の基礎
// ## TODO F# の基礎
// ## 形式意味論 (formal science)
// 形式意味論はプログラムの意味をはっきりさせる方法を見つけ,
// プログラミング言語に関する新たな事実を発見・証明することに興味・関心があります.
// 新しい言語の仕様化やコンパイラ最適化の工夫といった具体的なテーマから,
// プログラムの正当性の数学的証明といった抽象的なテーマまで幅広い議論があります.

// ### 構文論 (syntax) と意味論 (semantics)
// 構文はプログラムがどう見えるかを記述することで,
// 意味論はプログラムが何を意味するをを規定します.

// ### 仕様の定義
// 大きく分けて 3 つのアプローチがあります.
//
// - 実装による言語定義
// - 公式文書として仕様書を書く
// - 形式意味論の数学的技巧を駆使してプログラミング言語の意味を正確に記述する
//
// 第 1 の方法は Ruby が代表的でしょうか. MRI (Matz's Ruby Interpreter) という言語のリファレンス実装があり,
// この実装が仕様です.
// 第 2 の方法は C++, Java, ECMAScript などです.
// 第 3 の方法はラムダ計算などの手法を使います.
//
// このうちどれがいいとも言えません.
// 第 1 の手法はとにかく動くものがあるという利点がありますが,
// プログラムを読み込まない限り何が正しいのかわかりませんし,
// 実装されているものが仕様である以上, 形式的な「バグ」の定義も難しいでしょう.
//
// 一方, 第 2 の手法は仕様があっても実装がない状態が出てきます.
// これは例えば JavaScript (ECMAScript) で「仕様は固まったがまだ実装しているブラウザがない」といった形でよく言及されます.
// 他には仕様書とその記述に関する問題があります.
// 例えば矛盾や欠落・あいまいな記述があってもそれを見分けるのが難しいのです.
// 一般にドキュメントは膨大だからです.
// その矛盾を検証するための形式的手法は現在ありません.
// もし素朴な形で実現させようとするなら非常に高度な自然言語処理技術が必要でしょう.
//
// 第 3 の手法はよくも悪くも数学がその限界を決めます.
// たいていの人にとって読みにくい問題があるからです.
// その代わり厳格に記述でき曖昧さも限りなく削れます.
// 第 2 の手法でコメントした形式的手法,
// つまり矛盾や曖昧さの自動検出もしやすいメリットがあります.
//
// まずは構文論を確認したあと,
// 意味論・意味論的仕様に対する形式的アプローチを眺めます.

// ### 構文
// ふつうプログラムは文字の羅列でしかありません.
// すべてのプログラミング言語には,
// どんな文字列がその言語で有効なプログラムだと見なされるかを記述した規則があります.
// これらの規則が言語の構文 (syntax) を規定します.

// 構文規則によって意味があるプログラムとそうではないプログラムを識別できます.
// 例えば `y = x + 1` は多くの言語で意味を持つでしょうが `a%&$#` はそうではないでしょう.
// LISP なら `(+ 1 2)` は和の意味を持ちますが他の言語では違うはずです.

// 構文規則は曖昧なプログラムの意味も決めます.
// 例えば `1 + 2 * 3` は多くの言語で `1 + (2 * 3)` の意味です.
// これを `3 * 3`, つまり `(1 + 2) * 3` と読ませたいならふつう括弧が必要です.

// プログラムを読むためには構文解析をする道具が必要で,
// それはパーサー (parser) と呼ばれます.
// 構文規則をパーサー自動変換するツールもいろいろあります.
// パーサーは `y = x + 1` や `(1 + 2) * 3` のような文字列を抽象構文木 (AST: Abstract Syntax Tree) に変換します.
// AST はプログラムから空白などの不要な要素を除き,
// 階層構造に着目したプログラムの表現です.

// 構文で重要なのはそれがプログラムの見た目だけの問題で,
// 意味とは無関係なことです.
// 例えば `y = x + 1` は構文上は正しいように見えるかもしれませんが,
// いまの文脈では `x` を指定しない限り意味を持ちません.
// 強い型を持つ多くの言語では `z = true + 1` は意味を持ちませんが,
// これが意味を持つ言語もありえます.

// ### 操作的意味論
// プログラムの意味を考えるときプログラムが何をするのか考えるのが実践的です.
// プログラムを実行して何が起きるか,
// そのとき言語の構成要素がどう振る舞うか,
// 各構成要素を組み合わせて大きなプログラムを作るとどうなるか,
// これらを考えるのが操作的意味論 (operational sematincs) の基本です.

// プログラムがある装置 (抽象機械, abstract machine) の上でどう実行されるか,
// その規則を定義してプログラミング言語の意味を記述します.
// 抽象機械は架空の理想化したコンピューターで,
// ある言語で書かれたプログラムがどう実行されるか説明するための概念装置です.
// 当然言語ごとに別の機械を設計します.
// 操作的意味論とそれによる形式的仕様はその言語での構成要素を厳密・明確に定義します.

// #### スモールステップ意味論
// 抽象機械を設計してプログラミング言語の操作的意味論を記述する方法の 1 つとして,
// 構文を小さなステップでくり返し簡約 (reduce) してプログラムを評価する機械を考えましょう.
// ステップごとにプログラムは最終結果・最終的な意味に近づきます.

// スモールステップによる簡約は代数的な計算の評価方法に似ています.
// 実際に算数を例に取るとイメージしやすいでしょう.
// \begin{align}
// &(1 \times 2) + (3 \times 4)
// &= 2 + (3 \times 4) \\
// &= 2 + 12 \\
// &= 14.
// \end{align}
// 最終的に値 (value) に帰着します.
// 値はそれ自体で意味を持ちます.

// こう書く以上, それ自体では意味を持たない, 値以外の概念が存在します.
// P.21
