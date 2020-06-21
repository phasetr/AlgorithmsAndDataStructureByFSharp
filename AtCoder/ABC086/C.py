# https://atcoder.jp/contests/abc086/tasks/arc089_a
# https://atcoder.jp/contests/abs/tasks/arc089_a
# https://atcoder.jp/contests/abc086/submissions/14214601

n = int(input())
# 初期位置
x_old, y_old, t_old = 0, 0, 0

for _ in range(n):
    # 都度読み込み
    t, x, y = map(int, input().split())
    d = (t - t_old) - abs(x - x_old) - abs(y - y_old)
    if d >= 0 and d % 2 == 0:
        x_old, y_old, t_old = x, y, t
    else:
        print('No')
        exit()

print('Yes')
