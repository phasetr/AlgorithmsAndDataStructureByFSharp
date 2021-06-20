---
jupyter:
  jupytext:
    text_representation:
      extension: .md
      format_name: markdown
      format_version: '1.3'
      jupytext_version: 1.10.2
  kernelspec:
    display_name: Ruby 2.7.0
    language: ruby
    name: ruby
---

# はじめに


#### ファイルの内容表示関数
最初試行錯誤していた時、生のクラスを書いて何度もセルを読み込むとエラーになるので、クラス定義のソースは外出しして、こちらにはそのファイルを書き出す形で表示していました。
その名残です。

```ruby
def fout(fname)
  File.open(fname, mode="r"){ |f|
    f.each_line{|line|
      puts line.chomp
    }
  }
end
```

#### オブジェクト削除用関数
上の処理は新しいファイルを読み込むごとにオブジェクトを消すことで対応することにしました。

```ruby
def del_obj
  begin
    Object.send(:remove_const, :Number)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Add)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Multiply)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Boolean)
  rescue => e
  end

  begin
    Object.send(:remove_const, :LessThan)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Variable)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Machine)
  rescue => e
  end

  begin
    Object.send(:remove_const, :DoNothing)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Assign)
  rescue => e
  end

  begin
    Object.send(:remove_const, :If)
  rescue => e
  end

  begin
    Object.send(:remove_const, :Sequence)
  rescue => e
  end

  begin
    Object.send(:remove_const, :While)
  rescue => e
  end
end
```

# 第Ⅰ部 プログラムと機械
- 計算とは**コンピュータがやること**に付けた名前


#### 三つの基本的な構成要素
- 計算できる機械（machine）
- 機械が理解できる命令を書くための言語（language）
- その言語で書かれた機械が実行すべき計算を正確に記述したプログラム（program）


# 2章 プログラムの意味
- コンピュータプログラムの意味を明確にする技術を考える


## 2.1 「意味」の意味
- 言語学的な意味論（semantics）：言葉と意味の関係に関する学問
- 具象的記号はその抽象的意味や抽象的意味の基本的性質とどのように関係しているか？
- 形式意味論（formal semantics）
    - 新しい言語の仕様化・やコンパイラ最適化の工夫
    - プログラムの正当性の数学的証明


#### プログラミング言語の完全な記述に必要な要素
- ひとつは構文（syntax）：プログラムがどのように見えるか
- もうひとつは意味論：プログラムが何を意味するか


#### プログラミング言語を記述する方法
- 実装による言語定義
- 公式文書として仕様書を書く
    - 英語で書かれた仕様書について検証するための形式的手法は存在しない
- 形式意味論の数学的な技術でプログラミング言語の意味を正確に記述する
    - ここでの目標がこれ
    - あいまいさをなくす
    - 自動解析に適した形式で仕様を書く


## 2.2 構文
- 言語の構文規則で`y = x + 1`のような有効であろうプログラムと`>/;x:1@4`のような意味をなさないプログラムを区別する
- プログラムを読むためにはパーサ（parser）が必要
    - 抽象構文木(Abstract Syntax Tree)に変換する
- 構文：プログラムがどのように見えるか


## 2.3 操作的意味論
- 最も実践的な方法はプログラムが何をするのかを考えること
- 意味論：プログラムが何を意味するか？
- 抽象機械（abstract machine）


### 2.3.1 スモールステップ意味論
- 構文を小さなステップ（スモールステップ）で繰り返し簡約（reduce）してプログラムを評価するような機械を考える
- スモールステップによる簡約は学校で習った代数式の評価方法に似ている
- 小さな簡約ステップの進め方に関する形式的規則を決めると操作的意味論が作れる
    - これらの規則自体も何らかの言語（メタ言語（metalanguage））で記述する


#### SIMPLE
- 架空言語を作る
- SIMPLEの構成要素をNumber・Add・Multiplyとし、Rubyのクラスとして表現する
- P.21：SIMPLEのスモールステップ意味論（small-step semantics）の数学的説明の図が載っている


#### 注意
- ここでの「実装による仕様」はSIMPLEの意味論を記述する目的で作るのではない
- 数学の代わりにRubyを使うのは人間が理解しやすくするため

<!-- #region -->
#### 完成品のコード
- [SIMPLE.rb](chapter2/SIMPLE.rb)

このコードを使って手動で抽象構文木が作れる。
これを本に沿って順に書いていく。

```ruby
Add.new(
  Multiply.new(Number.new(1), Number.new(2)),
  Multiply.new(Number.new(3), Number.new(4))
)
```
<!-- #endregion -->

#### 実行（完成品）
先に完成品をロードして実行しておく。

```ruby
del_obj
simple = "./chapter02/SIMPLE.rb"
load simple
```

```ruby
Add.new(
  Multiply.new(Number.new(1), Number.new(2)),
  Multiply.new(Number.new(3), Number.new(4))
)
```

`1*2+3*4`相当の構文を表すことができた。


#### 2.3.1.1 式


##### SIMPLE01

```ruby
del_obj
simple = "./chapter02/SIMPLE01.rb"
load simple
```

##### SIMPLE01 テスト

```ruby
Number.new(2)
```

```ruby
Add.new(
  Multiply.new(Number.new(1), Number.new(2)),
  Multiply.new(Number.new(3), Number.new(4))
)
```

```
#<struct Add
    left=#<struct Multiply
        left=#<struct Number value=1>,
        right=#<struct Number value=2>
    >,
    right=#<struct Multiply
        left=#<struct Number value=3>,
    right=#<struct Number value=4>
    >
>
```


#### P.23 カスタムの文字列表現を返せるようにする


##### SIMPLE02

```ruby
del_obj
simple = "./chapter02/SIMPLE02.rb"
load simple
```

##### SIMPLE02 テスト

```ruby
Add.new(
  Multiply.new(Number.new(1), Number.new(2)),
  Multiply.new(Number.new(3), Number.new(4))
)
```

#### P.24 上の実装に関する注意
ここでの`#to_s`実装は演算子の優先順位を考えていないため、慣習的な優先順位の規則に対して出力が正しくないことがある。

下の木は`<<1 * (2 + 3) * 4>>`を表しているものの、
`<<1 * 2 + 3 * 4>>`とは違う式で別の意味を持つ。
文字列表現にこの違いを反映させていない。

```ruby
Multiply.new(
  Number.new(1),
  Multiply.new(
    Add.new(Number.new(2), Number.new(3)),
    Number.new(4)
  )
)
```

### P.24 簡約可能な式と簡約可能でない式の区別
- `Add`式と`Multiply`式は常に簡約可能
- `Number`式は簡約不可能


##### SIMPLE03

```ruby
del_obj
simple = "./chapter02/SIMPLE03.rb"
load simple
```

##### SIMPLE03 テスト

```ruby
Number.new(1).reducible? == false
```

```ruby
Add.new(Number.new(1), Number.new(2)).reducible? == true
```

#### P.26 簡約規則の追加
- 足し算の左の引数が簡約可能な場合には、左の引数を簡約する
- 足し算の左の引数が簡約可能ではなく、右の引数が簡約可能な場合には、右の引数を簡約する
- どちらの引数も簡約可能でない場合には、どちらも数値のはずなので、それらを足し合わせる


##### SIMPLE04

```ruby
del_obj
simple = "./chapter02/SIMPLE04.rb"
load simple
```

##### SIMPLE04 テスト

```ruby
expr = Add.new(
  Multiply.new(Number.new(1), Number.new(2)),
  Multiply.new(Number.new(3), Number.new(4))
)
```

```ruby
expr.reducible? == true
```

```ruby
expr = expr.reduce
```

```ruby
expr.reducible? == true
```

```ruby
expr = expr.reduce
```

```ruby
expr.reducible? == true
```

```ruby
expr = expr.reduce
```

```ruby
expr.reducible? == false
```

#### P.27 仮想機械
状態（現在の式）を持ち、最終的に値になるまで`#reducible?`と`#reduce`を繰り返し呼び出して式を評価してきました。
これを自動化してくれるコードを書きます。
コードと状態をクラスにまとめて仮想機械と呼びましょう。


##### SIMPLE05

```ruby
del_obj
simple = "./chapter02/SIMPLE05.rb"
load simple
```

##### SIMPLE05 テスト

```ruby
Machine.new(
  Add.new(
     Multiply.new(Number.new(1), Number.new(2)),
     Multiply.new(Number.new(3), Number.new(4))
  )
).run
```

#### P.28 実装の拡張


##### SIMPLE06

```ruby
del_obj
simple = "./chapter02/SIMPLE06.rb"
load simple
```

##### SIMPLE06 テスト

```ruby
Machine.new(
  LessThan.new(Number.new(5), Add.new(Number.new(2), Number.new(2)))
).run
```

#### P.29 SIMPLEを高機能化する
変数を追加するために`Variable`という式のクラスを導入します。
変数を簡約するためには抽象機械は現在の式に加えて変数名から値へのマッピングである環境（environment）を持つ必要があります。
シンボルをキー、式オブジェクトを値としたハッシュでこのマッピングを実装できます。

環境を与えれば`Variable#reduce`は簡単に実装できます。
この影響を受けて他の`reduce`メソッドも修正します。


##### SIMPLE07

```ruby
del_obj
simple = "./chapter02/SIMPLE07.rb"
load simple
```

####


##### SIMPLE07 テスト

```ruby
Machine.new(
  Add.new(Variable.new(:x), Variable.new(:y)),
  { x: Number.new(3), y: Number.new(4) }
).run
```

#### P.31 2.3.1.2 文
- 文（statement）：もうひとつのプログラム構成要素
- 式：評価されて別の式を生成する
- 文：評価されると抽象機械の状態を変更する
- 最も単純な文は、何もしない文
    - ここではプログラムが正しく終わったことを表すために使う
    - 以降、文が正しく終わったときは`«do-nothing»`に簡約する


##### `DoNothing`
- `DoNothing`は敬称がない：属性がなく`Struct.new`に空の属性名のリストを渡せない`Ruby`の都合

```ruby
class DoNothing
  def to_s
    'do-nothing'
  end

  def inspect
    "<<#{self}>>"
  end

  def ==(other_statement)
    other_statement.instance_of?(DoNothing)
  end

  def reducible?
    false
  end
end
```

#### P.32 実際に役に立つ一番単純な文
- `x = x + 1`のような代入（assignment）


#### P.33 注意
- SIMPLEのスモールステップ意味論での位置づけ
- 式は純粋（pure）
- 文は純粋ではない（impure）


##### SIMPLE08

```ruby
del_obj
simple = "./chapter02/SIMPLE08.rb"
load simple
```

##### SIMPLE08 テスト

```ruby
statement = Assign.new(:x, Add.new(Variable.new(:x), Number.new(1)))
```

```ruby
environment = { x: Number.new(2) }
```

```ruby
statement.reducible? == true
```

```ruby
statement, environment = statement.reduce(environment)
```

```ruby
statement, environment = statement.reduce(environment)
```

```ruby
statement, environment = statement.reduce(environment)
```

```ruby
statement.reducible? == false
```

#### P.34 文が使えるように仮想機械を再実装


##### SIMPLE09

```ruby
del_obj
simple = "./chapter02/SIMPLE09.rb"
load simple
```

```ruby
Machine.new(
    Assign.new(:x, Add.new(Variable.new(:x), Number.new(1))),
    { x: Number.new(2) }
).run
```

#### P.35 他の種類の分もサポートする
- まずは条件文の`if`から
- 条件（condition）、帰結（consequence）、代替（alternative）
    - 条件が簡約可能なら条件を簡約する：簡約された条件文ともとのままの環境が得られる
    - 条件が式`true`なら帰結文ともとのままの環境に簡約
    -  条件が式`false`ならば代替文ともとのままの環境に簡約


##### SIMPLE10

```ruby
del_obj
simple = "./chapter02/SIMPLE10.rb"
load simple
```

```ruby
Machine.new(
  If.new(
    Variable.new(:x),
    Assign.new(:y, Number.new(1)),
    Assign.new(:y, Number.new(2))
  ),
  { x: Boolean.new(true) } ).run
```

```ruby
Machine.new(
  If.new(Variable.new(:x), Assign.new(:y, Number.new(1)), DoNothing.new),
  { x: Boolean.new(false) }
).run
```

#### P.36 まだある制約
- 要素を互いにつなげられない
- シーケンス（sequence）文で改善する：大きな一つの文を作れる


#### P.36 シーケンス文の簡約規約
- 1番目の文が`«do-nothing»`文：2番目の文ともとのままの環境に簡約する。
- 1番目の文が`«do-nothing»`でない：1番目の文を簡約し、新しいシーケンス文（簡約された1番目の文に2番目の文が続いた文）と簡約された環境が得られる。
- 規則全体としては、シーケンス文を繰り返し簡約したとき1番目の文が`«do-nothing»`になるまで簡約を続けてから2番目の文を簡約する。


##### SIMPLE11

```ruby
del_obj
simple = "./chapter02/SIMPLE11.rb"
load simple
```

```ruby
Machine.new(
  Sequence.new(
    Assign.new(:x, Add.new(Number.new(1), Number.new(1))),
    Assign.new(:y, Add.new(Variable.new(:x), Number.new(3)))
  ),
  {}
).run
```

#### P.37 ループを作ろう
- `while`文を作ろう。
- 条件（condition）と呼ばれる式（`«x < 5»`）と本体（body）と呼ばれる文（`«x = x * 3»`）が含まれる。
- スモールステップ意味論
    - シーケンス文を使って`«while»`を1段だけ展開（unroll）する
    - ループを1回実行したらもとの`«while»`文を繰り返す`«if»`文に簡約する。


##### SIMPLE12

```ruby
del_obj
simple = "./chapter02/SIMPLE12.rb"
load simple
```

```ruby
Machine.new(
  While.new(
    LessThan.new(Variable.new(:x), Number.new(5)),
    Assign.new(:x, Multiply.new(Variable.new(:x), Number.new(3)))
  ),
  { x: Number.new(1) }
).run
```

#### P.39 2.3.1.3 正当性
- 構文的には有効でも正しくないプログラムを無視してきた
- 例を見よう：最終的に`«true»`に`«1»`を足そうとしてエラー

```ruby
begin
  Machine.new(
    Sequence.new(
      Assign.new(:x, Boolean.new(true)),
      Assign.new(:x, Add.new(Variable.new(:x), Number.new(1)))
    ),
    {}
  ).run
rescue => e
  p e.message
end
```

#### P.40 対処法
- 対処法その1：式が簡約可能かどうかをもっと制限する
- 評価が停止する可能性が生まれる
- 究極的には構文よりも強力なツールが必要
    - 「将来を見通して」失敗したり停止したりする可能性のあるプログラムの実行を防いでくれるツールが必要
- 9章：静的意味論（static semantics）で構文的に有効なプログラムがその動的意味論にしたがって意味があるかどうかを判断する方法を見る


#### P.40 2.3.1.4 応用
- 意味論を変えると構文は同じでも実行時の振る舞いが違う新しい言語を記述できる
- プログラミング言語Schemeの最新のR6RS標準
    - 実行記述に[スモールステップ意味論](http://www.r6rs.org/final/html/r6rs/r6rs-Z-H-15.html)を使っている
- OCaml：Core MLというもっと単純な言語の上に階層状に構築されている
    - そのベース言語の実行時の振る舞いの[スモールステップ意味論定義](http://caml.inria.fr/pub/docs/u3-ocaml/ocaml-ml.html#htoc5)が存在する
- スモールステップ操作的意味論で式の意味をもっと単純なラムダ計算（lambda calculus）と呼ばれるプログラミング言語で記述する例は「6.2.2 意味論」を参照すること


### P.41 2.3.2 ビッグステップ意味論
- 反復（iterative）：スモールステップ意味論の特徴
- 簡約規則を繰り返し実行する（`Machine#run`における`Ruby`の`while`ループ）ための抽象機械が必要
- 簡約規則そのものは必要な情報を入力として受け取って同種の情報を出力として生成するように構成される
- スモールステップ意味論の利点：プログラム全体の実行という複雑な仕事を説明や解析のしやすい小さなパーツに切り分ける
    - やや間接的
    - プログラム全体がどのように動くのかを説明しているのではなく、どのように簡約していくかを示す
- ビッグステップ意味論（big-step semantics）：完結した話としてもっと直接的に説明
    - 実行プロセスを反復ではなく再帰（recursive）とみなす
    - 大きな式を評価するために小さな部分式をすべて評価し、それらを組み合わせて最終的な答えを得る
    - 言語の詳細がよくわからない
- Rubyでビッグステップ意味論をどのように実装できるか調べよう
- Machineクラスがいらない
    - 抽象構文木を一度走査し、どうやってプログラム全体の結果を計算するかを記述する
    - 状態や繰り返しは出てこない


#### P.42 2.3.2.1 式
- スモールステップ意味論では`«1 + 2»`のような簡約可能な式と`«3»`のような簡約不可能な式を区別する必要がある
- ビッグステップ意味論ではすべての式を評価できる
    - あえて区別するとしたら即座に自分自身に評価される式か、計算を実行して別の式に評価される式か


##### SIMPLE13

```ruby
del_obj
simple = "./chapter02/SIMPLE13.rb"
load simple
```

```ruby
Number.new(23).evaluate({})
```

```ruby
Variable.new(:x).evaluate({ x: Number.new(23) })
```

```ruby
LessThan.new(
  Add.new(Variable.new(:x), Number.new(2)),
  Variable.new(:y)
).evaluate({ x: Number.new(2), y: Number.new(5) })
```

#### P.43 2.3.2.2 文
- ビッグステップ意味論での文の評価：文と初期環境を最終的な環境に変えるプロセス
- スモールステップ意味論での`#reduce`による中間文がなくなる
- シーケンス文と`«while»`ループについて
    - シーケンス文の場合、ふたつの文を評価する必要がある
    - 最初の環境がこれらふたつの評価に「渡されていく」必要がある


##### SIMPLE14

```ruby
del_obj
simple = "./chapter02/SIMPLE14.rb"
load simple
```

```ruby
statement = Sequence.new(
  Assign.new(:x, Add.new(Number.new(1), Number.new(1))),
  Assign.new(:y, Add.new(Variable.new(:x), Number.new(3)))
)
```

```ruby
statement.evaluate({})
```

#### P.44 While文の評価
- `«while»`文がどのように振る舞うべきかを再帰的に説明する
- `«while»`文の場合はループを完全に評価するステージを考える必要がある
    - 条件を評価して`«true»`か`«false»`のどちらかを得る。
    - 条件が`«true»`に評価された場合まず本体を評価して新しい環境を得る
        - その新しい環境でループを繰り返して最終的な環境を返す
        - つまり`«while»`全体を再度評価する
    - 条件が`«false»`に評価された場合もとのままの環境を返す


##### SIMPLE15

```ruby
del_obj
simple = "./chapter02/SIMPLE15.rb"
load simple
```

```ruby
statement = While.new(
  LessThan.new(Variable.new(:x), Number.new(5)),
  Assign.new(:x, Multiply.new(Variable.new(:x), Number.new(3)))
)
```

```ruby
statement.evaluate({ x: Number.new(1) })
```

#### P.46 2.3.2.3 応用
- スモールステップ意味論の実装ではRubyのコールスタックは少なく済む
    - コールスタックの深さはプログラムの構文木の深さに制限される
    - 小さな操作を実行する単純な抽象機械を想定
- ビッグステップ意味論の実装はスタックを多用する
    - 計算全体のどこにいるのか
    - 大きな計算の一部として小さな計算を実行
    - 評価すべき対象がどれくらい残っているか
    - 計算全体を組み立てる負担を抽象機械に任せる
- 操作的意味論を使って実現したいことに合わせてふさわしいアプローチは変わる


## P.47 2.4 表示的意味論
- ここまで：プログラミング言語の意味を操作の観点から見た
- 表示的意味論（denotational semantics）：プログラムをネイティブ言語から別の表現に変換することに関心がある
- もともと表示的意味論はプログラムを数学的オブジェクトに変換するために使われた
- 「意図した意味」とは何か？式や文のRubyによる表示はどのように見えるべきか？


### P.48 2.4.1 式
- `#to_ruby`を実装する


##### SIMPLE16

```ruby
del_obj
simple = "./chapter02/SIMPLE16.rb"
load simple
```

```ruby
Number.new(5).to_ruby
```

```ruby
Boolean.new(false).to_ruby
```

```ruby
proc = eval(Number.new(5).to_ruby)
```

```ruby
proc.call({}) == 5
```

```ruby
proc = eval(Boolean.new(false).to_ruby)
```

```ruby
proc.call({}) == false
```

### 環境を使った式の表示
- 環境をどのようにRubyで表現するか？
- 操作的意味論：環境は仮想機械内にあり変数名を`SIMPLE`の抽象構文木に関連付けた
- 表示的意味論：環境はプログラムの変換先の言語内にある
- 実装メタ言語と表示言語がどちらもRubyなので何をどう考えているか注意する


##### SIMPLE17

```ruby
del_obj
simple = "./chapter02/SIMPLE17.rb"
load simple
```

```ruby
expression = Variable.new(:x)
```

```ruby
expression.to_ruby
```

```ruby
proc = eval(expression.to_ruby)
```

```ruby
proc.call({ x: 7 }) == 7
```

### 合成（compositional）


##### SIMPLE18

```ruby
del_obj
simple = "./chapter02/SIMPLE18.rb"
load simple
```

```ruby
Add.new(Variable.new(:x), Number.new(1)).to_ruby
```

```ruby
LessThan.new(Add.new(Variable.new(:x), Number.new(1)), Number.new(3)).to_ruby
```

```ruby
environment = { x: 3 }
```

```ruby
proc = eval(Add.new(Variable.new(:x), Number.new(1)).to_ruby)
```

```ruby
proc.call(environment) == 4
```

```ruby
proc = eval(
  LessThan.new(Add.new(Variable.new(:x), Number.new(1)), Number.new(3)).to_ruby
)
```

```ruby
proc.call(environment) == false
```

### P.51 2.4.2 文
- 文の表示的意味論も同じように書ける
- 注意：操作的意味論における文の評価は値ではなく新しい環境を生成する
- `Assign#to_ruby`は環境のハッシュを更新する`proc`のコードを生成する必要がある


##### SIMPLE19

```ruby
del_obj
simple = "./chapter02/SIMPLE19.rb"
load simple
```

```ruby
statement = Assign.new(:y, Add.new(Variable.new(:x), Number.new(1)))
```

```ruby
statement.to_ruby
```

```ruby
proc = eval(statement.to_ruby)
```

```ruby
proc.call({ x: 3 })
```

##### P.52 SIMPLE20

```ruby
del_obj
simple = "./chapter02/SIMPLE20.rb"
load simple
```

```ruby
statement =
  While.new(
    LessThan.new(Variable.new(:x), Number.new(5)),
    Assign.new(:x, Multiply.new(Variable.new(:x), Number.new(3)))
  )
```

```ruby
statement.to_ruby
```

```ruby
proc = eval(statement.to_ruby)
```

```ruby
proc.call({ x: 1 })
```

#### P.52 意味論のスタイルの比較
- スモールステップ意味論・ビッグステップ意味論・表示的意味論のスタイルの違いを理解するには`«while»`の違いを見るとよい
- `«while»`のスモールステップ操作的意味論：抽象機械のための簡約規則
    - 規則のアクション部にループ全体の振る舞いは出てこない：簡約規則は`«while»`文を`«if»`文に変換するだけ
- `«while»`のビッグステップ操作的意味論：最終的な環境を直接計算する方法を示した評価規則
    - 規則は自分自身に対する再帰呼び出しを含む
    - SIMPLEプログラマが認識しているループと一致するとは限らない
- `«while»`の表示的意味論は：Rubyで書き直す


### P.53 2.4.3 応用
- 操作的意味論：インタプリタの設計、言語の意味の説明
- 表示的意味論：言語から言語への変換はコンパイラ（compiler）に似ている
    - `#to_ruby`の実装は事実上`SIMPLE`の`Ruby`へのにコンパイル
- 表示的意味論で正規表現の意味論を記述する例：「3.3.2 意味論」を参照


## P.54 実際の形式意味論
- ふつうは数学での記述を指す


### P.54 2.5.1 形式
- きちんと定義された数学的オブジェクトに変換してプログラムの核心に迫ることに関心がある
- 領域理論（domain theory）：表示的意味論に役立つ定義とオブジェクトを提供するために特別に作られた
    - 半順序集合上の単調関数の不動点に基づく計算モデルが作れる


### P.54 2.5.2 意味の理解
- 形式的な表示的意味論では抽象的な数学的オブジェクト（ふつうは関数）で式や文といったプログラミング言語の構成要素を表示する
- 数学的規約が関数の評価方法などを決定付ける
- 表示をそのまま操作的に考えられる


### P.55 2.5.3 その他のスタイル
- この章で見てきた意味論には、さまざまな呼び名が付いている
- スモールステップ意味論: 構造的操作的意味論（structural operational semantics）、遷移意味論（transition semantics）
- ビッグステップ意味論: 自然意味論（natural semantics）や関係意味論（relational semantics）
- 表示的意味論: 不動点意味論（fixed-point semantics）や数学的意味論（mathematical semantics）
- その他の形式意味論のスタイル: 公理的意味論（axiomatic semantics）
- 公理的意味論: 文を実行する前後の抽象機械の状態を表明（assertion）することで文の意味を記述
## P.55, 2.6 パーサの実装
- SIMPLEのソースコードからパーサーで構文木に変換したい
- 簡単に概要を説明
- `Treetop`: 言語の構文をPEG（Parsing Expression Grammar）として記述
- `simple.treetop`は省略
- パーサーの実装は4.3節参照
