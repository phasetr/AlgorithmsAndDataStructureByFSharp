# https://yottagin.com/?p=1628
import sys
sys.setrecursionlimit(10**5+10)
n = int(input())
h = [int(i) for i in input().split()]
# 無限大の値
f_inf = float('inf')
# メモ用のDP テーブルを初期化(最小化問題なので INF に初期化)
dp = [f_inf] * (10**5+10)
# dpの最小値を変更する関数
def chmin(a, b):
    if a > b:
        return b
    else:
        return a
# メモ化再帰の関数
def rec(i):
    # DPの値が更新されている場合はその値を返す
    if dp[i] <  f_inf:
        return dp[i]

    # 再帰の終了条件。足場0のコストは0
    if i == 0:
        return 0

    # i-1, i-2 を再帰
    res = f_inf
    # i-1 から来た場合
    res = chmin(res, rec(i-1) + abs(h[i] - h[i-1]))
    # i-2 から来た場合
    if i > 1:
        res = chmin(res, rec(i-2) + abs(h[i] - h[i-2]))

    # 結果をメモする
    dp[i] = res
    return res
ans = rec(n-1)
print(ans)
