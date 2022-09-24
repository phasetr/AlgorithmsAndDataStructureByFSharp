# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/5261251/noimi/Python3
import copy, heapq
def solve():
    def hash(a):
        res = 0
        for i in range(4):
            for j in range(4):
                res += a[i][j] * pow(2, 4 * (i * 4 + j))
        return res

    checked = set()

    score = 0
    zi, zj = 0, 0

    s = [list(map(int, input().split())) for _ in range(4)]
    for i in range(4):
        for j in range(4):
            if s[i][j] != 0:
                score += abs(i - (s[i][j] - 1) // 4) + abs(j - (s[i][j] - 1) % 4)
            else:
                zi, zj = i, j

    checked.add(hash(s))

    dx = [0, 1, 0, -1]
    q = [(score, score, 0, hash(s), zi, zj)]

    while q:
        cost, score, dist, now, r, c = heapq.heappop(q)

        if score == 0:
            print(dist)
            exit(0)

        for t in range(4):
            ni, nj = r + dx[t], c + dx[t ^ 1]
            if 0 <= ni and 0 <= nj and ni < 4 and nj < 4:
                x = (now >> (4 * (ni * 4 + nj))) % 16
                nxt = now + x * ((1 << (4 * (r * 4 + c))) - (1 << (4 * (ni * 4 + nj))))

                if not nxt in checked:
                    nd = score
                    nd -= abs((x - 1) // 4 - ni) + abs((x - 1) % 4 - nj)
                    nd += abs((x - 1) // 4 - r) + abs((x - 1) % 4 - c)

                    checked.add(nxt)
                    heapq.heappush(q, (nd + dist + 1, nd, dist + 1, nxt, ni, nj))

if __name__ == '__main__':
    solve()
