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
