# README
- <https://atcoder.jp/contests/abc049/tasks/arc065_a>
## C - 白昼夢 問題文
英小文字からなる文字列S が与えられます。
Tが空文字列である状態から始め、以下の操作を好きな回数繰り返すことで S=T とすることができるか判定してください。

- T の末尾に dream dreamer erase eraser のいずれかを追加する。
## 制約
- 1≦∣S∣≦10^5
- S は英小文字からなる。
## 入力
入力は以下の形式で標準入力から与えられる。

```
S
```
## 出力
S=T とすることができる場合 YES を、そうでない場合 NO を出力せよ。
## 入力例 1
```
erasedream
```
## 出力例 1
```
YES
```
erase dream の順で T の末尾に追加することで S=T とすることができます。
## 入力例 2
```
dreameraser
```
## 出力例 2
```
YES
```

dream eraser の順でT の末尾に追加することでS=T とすることができます。
## 入力例 3
```
dreamerer
```
## 出力例 3
```
NO
```
