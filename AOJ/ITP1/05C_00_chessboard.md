# README
- <https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_5_C>
## チェスボードの描画
以下のような、たてH cm よこ W cm のチェック柄の長方形を描くプログラムを作成して下さい。

```
#.#.#.#.#.
.#.#.#.#.#
#.#.#.#.#.
.#.#.#.#.#
#.#.#.#.#.
.#.#.#.#.#
```

上図は、たて 6 cm よこ 10 cm の長方形を表しています。
長方形の左上が "#" となるように描いて下さい。
### Input
入力は複数のデータセットから構成されています。各データセットの形式は以下のとおりです：

```
H W
```

H, W がともに 0 のとき、入力の終わりとします。
## Output
各データセットについて、たて H cm よこ W cm の枠を出力して下さい。
各データセットの後に、１つの空行を入れて下さい。
## Constraints
- 1 ≤ H ≤ 300
- 1 ≤ W ≤ 300
## Sample Input
```
3 4
5 6
3 3
2 2
1 1
0 0
```
## Sample Output
```
#.#.
.#.#
#.#.

#.#.#.
.#.#.#
#.#.#.
.#.#.#
#.#.#.

#.#
.#.
#.#

#.
.#

#
```
