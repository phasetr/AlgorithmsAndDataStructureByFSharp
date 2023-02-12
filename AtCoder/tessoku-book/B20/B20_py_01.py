# https://atcoder.jp/contests/tessoku-book/submissions/36596436
S = input()
T = input()

cur = list(range(len(T)+1))
for i in range(1, len(S)+1):
    prev = cur
    cur = [i] * (len(T)+1)
    for j in range(1, len(T)+1):
        cost = 0 if S[i-1] == T[j-1] else 1
        cur[j] = min(prev[j] + 1, cur[j-1] + 1, prev[j-1] + cost)
print(cur[-1])
