# https://atcoder.jp/contests/dp/submissions/26212079
# from functools import lru_cache
import sys
sys.setrecursionlimit(10**7)
readline = sys.stdin.readline

N,M,xy = 3,100,[[1,2],[2,3]]
def solve(N,M,xy):
    G = [[] for _ in range(N)]
    for x, y in xy:
        x -= 1
        y -= 1
        G[x].append(y)
        G[y].append(x)

    res = [1 for _ in range(N)]
    L = [[1] for _ in range(N)]
    R = [[1] for _ in range(N)]

    def dfs(i=0, p=-1):
        G[i] = [j for j in G[i] if j != p]
        for j in G[i]:
            L[i].append(L[i][-1] * (dfs(j, i) + 1) % M)
        for j in G[i][::-1]:
            R[i].append(R[i][-1] * (res[j] + 1) % M)
        R[i].reverse()
        res[i] = L[i][-1]
        return res[i]

    def bfs(i=0, x=1):
        for idx, j in enumerate(G[i]):
            y = x * L[i][idx] * R[i][idx + 1] + 1
            y %= M
            res[j] *= y
            res[j] %= M
            bfs(j, y)

    dfs()
    bfs()
    return res

def main():
    N, M = map(int, readline().split())
    xy = [tuple(map(int, readline().split())) for _ in range(N - 1)]
    res = solve(N,M,xy)
    print(*res, sep='\n')

def test():
    print(solve(N,M,xy) == [3,4,3])
    print(solve(4,100,[[1,2],[1,3],[1,4]]) == [8,5,5,5])
    print(solve(1,100,[]) == [1])
    print(solve(10,2,[[8,5],[10,8],[6,5],[1,5],[4,8],[2,10],[3,6],[9,2],[1,7]]) == [0,0,1,1,1,0,1,0,1,1])
test()
