# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/5106135/salmon0852/Python3
from collections import deque

def swap(s, i, j):
    ls = list(s)
    ls[i], ls[j] = ls[j], ls[i]
    return ''.join(ls)

goal = ''
for i in range(3): goal += input().replace(' ', '')

start = ''.join([str(i) for i in range(1, 9)]) + '0'
ng = [[2, 3], [3, 2], [5, 6], [6, 5]]

used = {start : 0}
que = deque([[start, 8, 0]])

while que:
    puz, p, cnt = que.popleft()
    #print(puz, p, cnt)
    if puz == goal:
        ans = cnt
        break

    for d in [val for val in [p-1, p+1, p-3, p+3] if 0 <= val <= 8 and [p, val] not in ng]:
        tmp = swap(puz, p, d)
        if tmp in used:
            continue
        que.append([tmp, d, cnt+1])
        used[tmp] = cnt + 1

print(ans)
