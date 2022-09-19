# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/6060954/lloyz_nt/Python3from collections import deque
edge = {}
edge[0] = [1, 3]
edge[1] = [0, 2, 4]
edge[2] = [1, 5]
edge[3] = [0, 4, 6]
edge[4] = [1, 3, 5, 7]
edge[5] = [2, 4, 8]
edge[6] = [3, 7]
edge[7] = [4, 6, 8]
edge[8] = [5, 7]

A = [list(map(int, input().split())) for _ in range(3)]
initial = 0
for i in range(3):
    for j in range(3):
        initial += A[i][j] * 10**(3 * i + j)

dq = deque([(initial, 0)])
visited = set([initial])
while dq:
    state, cnt = dq.popleft()
    if state == 87654321:
        print(cnt)
        break
    state_c = state
    for i in range(9):
        if state_c % 10 == 0:
            v = i
            break
        state_c //= 10
    for t in edge[v]:
        state_c = state
        t_num = (state_c // 10**t) % 10
        state_c -= t_num * 10**t
        state_c += t_num * 10**v
        if state_c in visited:
            continue
        visited.add(state_c)
        dq.append((state_c, cnt + 1))
