# README
- <https://atcoder.jp/contests/code-festival-2017-qualc/tasks/code_festival_2017_qualc_c>
## C - Inserting 'x' / 問題文
英小文字のみからなる文字列s があります。
すぬけ君は、次の操作を繰り返し行うことができます。

- s の任意の位置 (先頭および末尾を含む) をひとつ選び、英小文字 x をひとつ挿入する。

すぬけ君の目標は、s を回文にすることです。
すぬけ君の目標が達成可能か判定し、達成可能ならば必要な操作回数の最小値を求めてください。
## 注釈
回文とは、前後を反転しても変わらない文字列のことです。
例えば、a, aa, abba, abcba は回文ですが、ab, abab, abcda は回文ではありません。
## 制約
- 1≤∣s∣≤10^5
- s は英小文字のみからなる。
## 入力
入力は以下の形式で標準入力から与えられる。

```
s
```
## 出力
すぬけ君の目標が達成可能ならば、必要な操作回数の最小値を出力せよ。
達成不可能ならば、代わりに -1 を出力せよ。
## 入力例 1
```
xabxa
```
## 出力例 1
```
2
```

例えば、次のように操作を行えばよいです (新しく挿入された x は太字で表されています)。

- xabxa → xaxbxa → xaxbxax
## 入力例 2
```
ab
```
## 出力例 2
```
-1
```

どのように操作を行っても、s を回文にできません。
## 入力例 3
```
a
```
## 出力例 3
```
0
```

s は最初から回文です。
## 入力例 4
```
oxxx
```
## 出力例 4
```
3
```

例えば、次のように操作を行えばよいです。

- oxxx → xoxxx → xxoxxx → xxxoxxx