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


## オブジェクト削除用関数

```ruby
def del_obj
  begin
    Object.send(:remove_const, :FARule)
  rescue => e
  end

  begin
    Object.send(:remove_const, :DFARulebook)
  rescue => e
  end

  begin
    Object.send(:remove_const, :DFA)
  rescue => e
  end

  begin
    Object.send(:remove_const, :DFADesign)
  rescue => e
  end
end
```

# P.63 3章 最も単純なコンピュータ
- 計算する機械というアイデアにある本質を明らかにする
- それがどんな用途に使えるのか
- 単純なコンピュータにできることに対する制限を考える

## P.63 3.1 決定性有限オートマトン
- 有限状態機械（finite state machine）は有限オートマトン（finite automaton）と呼ばれる
- コンピューターを単純化したモデル

### P.63 3.1.1 状態、規則、入力
- 有限オートマトンには永続的ストレージがない
- RAMもない
- 有限オートマトン: いくつかの取り得る状態（state）と現在どの状態にいるかを記録する能力を備えた小さな機械
- 現在の状態という値1つを持つだけのRAMを備えたコンピューターとみなす
- 一度に1文字しか読めない外部入力ストリームを1つだけ持つ
- 入力に応じてある状態から別の状態への移動方法を決める規則（rule）の集合がハードコードされている
- 参考: P.64 図3-1

### P.65 3.1.2 出力
- 有限オートマトンは基本的な出力生成手段を持つ
- 受理状態（accept state）
- 文字のシーケンスを読んでそれが受理できるかどうかイエスかノーで示すという機械: 単純なコンピュータ

#### 表3-1
|                  | 実際のコンピュータ                        | 有限オートマトン                                 |
|------------------|-------------------------------------------|--------------------------------------------------|
| 永続的ストレージ | ハードディスクもしくはSSD                 | なし                                             |
| 一時的ストレージ | RAM                                       | 現在の状態                                       |
| 入力             | キーボード, マウス, ネットワークなど      | 文字ストリーム                                   |
| 出力             | 表示デバイス,スピーカー, ネットワークなど | 現在の状態が受理状態であるか（イエス・ノー）     |
| プロセッサ       | 任意のプログラムを実行できるCPUコア       | 入力に応じて状態を変更するハードコードされた規則 |

### P.66 3.1.3 決定性
- この種のオートマトンは決定的である（deterministic）
- 次の2つの制約を守る限り保証される
    - 無矛盾性
    - 省略がないこと
- 機械は状態と入力の組み合わせに対して必ずひとつだけ規則を持つ
- この決定性制約にしたがう機械を**決定性有限オートマトン（DFA：Deterministic Finite Automaton）**と呼ぶ

### P.66 3.1.4 シミュレーション
- 計算の抽象モデルとしてDFAを使う
- 規則の集合を実装する: **規則集(rulebook)**と呼ぶ.

##### dfa_rule01.rb
- それぞれの規則が持つメソッド
    - `#applies_to?`: ある特定の状態で規則を適用できるかどうか（true/false）を返す
    - `#follow`: 規則を適用するときに機械をどのように変更するかを返す
- 注意
    - 適用できる規則がひとつもないと`#detect`の呼び出しはnilを返す
    - `nil.follow`を呼び出そうとしてシミュレーションはクラッシュする

```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule01.rb"
load dfa
```

```ruby
rulebook = DFARulebook.new([
  FARule.new(1, 'a', 2), FARule.new(1, 'b', 1),
  FARule.new(2, 'a', 2), FARule.new(2, 'b', 3),
  FARule.new(3, 'a', 3), FARule.new(3, 'b', 3)
])
```

```ruby
rulebook.next_state(1, 'a') == 2
```

```ruby
rulebook.next_state(1, 'b') == 1
```

```ruby
rulebook.next_state(2, 'b') == 3
```

#### P.68 規則集ができたら
現在の状態を記録し, 受理状態かどうか報告するDFAオブジェクトを作る.

##### dfa_rule02.rb
```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule02.rb"
load dfa
```

```ruby
DFA.new(1, [1, 3], rulebook).accepting? == true
```

```ruby
DFA.new(1, [3], rulebook).accepting? == false
```

#### P.68 メソッド追加
- 入力から一文字読み, 規則集に応じて現在の状態を変えるメソッドを追加する.

##### dfa_rule03.rb
DFAに文字を与えて出力が変わるのを観察する.

```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule03.rb"
load dfa
```

```ruby
dfa = DFA.new(1, [3], rulebook); dfa.accepting? == false
```

```ruby
dfa.read_character('b'); dfa.accepting? == false
```

```ruby
3.times do dfa.read_character('a') end; dfa.accepting? == false
```

```ruby
dfa.read_character('b'); dfa.accepting? == true
```

#### P.69 メソッド追加
与えた入力文字列をすべて読むことができる便利なメソッドを追加する.

##### dfa_rule04.rb

```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule04.rb"
load dfa
```

```ruby
dfa = DFA.new(1, [3], rulebook); dfa.accepting? == false
```

```ruby
dfa.read_string('baaab'); dfa.accepting? == true
```

#### P.69 DFAの設計を表現するオブジェクト
- 一度入力を読んだDFAオブジェクトは開始状態にいる保証がない
- 新しい入力シーケンスのチェックでそのオブジェクトが再利用できる保証がない
- 新しい文字列をチェックするたびに前と同じ開始状態・受理状態・規則集を使って最初からDFAを生成する必要がある
- 面倒なので特定のDFAの設計（design）を表現するオブジェクトを作る
     - そこにDFAのコンストラクタに渡す引数を格納する
     - 文字列をチェックするたびに使い捨てのDFAのインスタンスを自動で作る

##### dfa_rule05.rb
```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule05.rb"
load dfa
```

```ruby
dfa_design = DFADesign.new(1, [3], rulebook)
```

```ruby
dfa_design.accepts?('a') == false
```

```ruby
dfa_design.accepts?('baa') == false
```

```ruby
dfa_design.accepts?('baba') == true
```

## P.70 3.2 非決定性有限オートマトン
- これまでの仮定や制約を取り除いてみる
- 決定性制約の制限を外す
    - 私たちはすべての状態ですべての可能な入力文字に関心があるわけではない
    - 想定外の入力に対して機械は失敗状態になる
    - 機械が矛盾する規則を持つことを許す
- 何も読まなくても状態を変えられることにする
### P.70 3.2.1 非決定性
- 図3-4の有限オートマトンを考える: 3番目の文字がbである限り文字a・bからなる任意の文字列を受理する
- **最後から3番目の文字がb**である文字列を受理する機械はどうすれば設計できるか?
    - 決定性制約を緩和して与えられた状態と入力に対して複数の規則を含む（あるいは規則がない）規則集を許せば機械を設計できる
- これを**非決定性有限オートマトン（NFA：Nondeterministic Finite Automaton）**と呼ぶ
- 入力シーケンスに対して複数の実行パスがある
- 言語 (language): 特定の機械が受理する文字列の集合
- 「この機械はその言語を認識する」と言う
- すべての言語にそれを認識できるDFAやNFAが存在するわけではない: 詳細については4章
- 有限オートマトンが認識できる言語を正規言語（regular languages）と呼ぶ
- 決定的なコンピュータでNFAをシミュレートするためには, その機械のすべての可能な実行を調べる方法を見つける
    - すべての可能性を再帰的に試す
    - 複雑なのが問題: DFAのようにシンプルにできないか?
    - 取り得る現在の状態をすべて記録する

##### dfa_rule06.rb
```ruby
del_obj
dfa = "./chapter03-rb/dfa_rule06.rb"
load dfa
```

```ruby
rulebook = NFARulebook.new([
  FARule.new(1, 'a', 1), FARule.new(1, 'b', 1), FARule.new(1, 'b', 2),
  FARule.new(2, 'a', 3), FARule.new(2, 'b', 3),
  FARule.new(3, 'a', 4), FARule.new(3, 'b', 4)
])
```

```ruby
rulebook.next_states(Set[1], 'b') == Set[1,2]
```

```ruby
rulebook.next_states(Set[1, 2], 'a') == Set[1,3]
```

```ruby
rulebook.next_states(Set[1, 3], 'b') == Set[1, 2, 4]
```

##### dfa_rule07.rb
シミュレートする機械を表現するNFAクラスを実装.
