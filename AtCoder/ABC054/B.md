# README
- <https://atcoder.jp/contests/abc054/tasks/abc054_b>
## 問題文
縦N 行、横 N 列に画素が並んだ画像Aと、縦 M 行、横 M 列に画素が並んだテンプレート画像Bが与えられます。
画素は画像を構成する最小単位であり、ここでは1×1 の正方形とします。
また、与えられる画像は全て2値画像であり、各画素の色は白と黒の2種類で表されます。

入力において、全ての画素は文字で表されており、.は白色の画素、 # は黒色の画素に対応します。
画像AはN 個の文字列 A1​,...,AN​ で表されます。
文字列 Ai​ の j 文字目は、画像Aの上から i 番目、左から j 番目の画素に対応します。(1≦i,j≦N)
同様に、テンプレート画像Bは M 個の文字列 B1​,...,BM​ で表されます。
文字列 Bi​ の j 文字目は、テンプレート画像Bの上から i 番目、左から j 番目の画素に対応します。(1≦i,j≦M)
画像の平行移動のみ許されるとき、テンプレート画像Bが画像Aの中に含まれているかを判定してください。
## 制約
- 1≦M≦N≦50
- Ai​ は # と . からなる長さN の文字列
- Bi​ は # と . からなる長さM の文字列
## 入力
入力は以下の形式で標準入力から与えられる。

```
N M
A1
A2
:
AN
B1
B2
:
BM
```
## 出力
画像Aの中にテンプレート画像Bを含む場合は Yes、含まない場合は No を出力せよ。
## 入力例 1
```
3 2
#.#
.#.
#.#
#.
.#
```
## 出力例 1
```
Yes
```

テンプレート画像Bが、画像A中の左上の2×2 の部分画像と右下の2×2 の部分画像に一致するため、Yes と出力します。
## 入力例 2
```
4 1
....
....
....
....
#
```
## 出力例 2
```
No
```

画像Aは白色の画素、テンプレート画像Bは黒色の画素で構成されるため、含まれることはありません。