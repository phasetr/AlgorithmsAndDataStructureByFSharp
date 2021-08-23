# README
## 対応
ファイル名はそれが載っているページ数を表す.

- 040: Top 3, ソートして上から三つ取る
- 046: ALDS 1_1_D: Maximum Profit, 最大利益を取る
- 055: ALDS 1_1_A: Insertion Sort, 挿入ソート
- 060: ALDS 1_2_A: Bubble Sort

## docker コマンド
```sh
docker compose up -d
docker compose exec cpp sh
docker compose kill
```

## C++ 実行
```sh
docker compose exec cpp sh
cd /home/cpp/src
g++ 040.cpp -o 040.out ; ./040.out < 040.txt
```

```sh
docker compose exec cpp sh
cd /home/cpp/src
make 040
```
