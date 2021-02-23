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