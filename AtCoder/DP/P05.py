# https://atcoder.jp/contests/dp/submissions/30404888
import sys
sys.setrecursionlimit(10 ** 6)
MOD = 10 ** 9 + 7

def dfs(G,u,p):
    w = 1
    b = 1
    for v in G[u]:
        if v != p:
            vw, vb = dfs(G,v,u)
            w = w * (vw + vb) % MOD
            b = b * vw % MOD
    return (w, b)

def solve(G):
    return sum(dfs(G,0,-1))%MOD

def main():
    N = int(input())
    G = [[] for i in range(N)]
    for i in range(N - 1):
        x,y = map(int, input().split())
        x,y = x - 1, y - 1
        G[x].append(y)
        G[y].append(x)
    print(solve(G))

def help(N,l):
    G = [[] for i in range(N)]
    for i in range(N-1):
        [x,y] = l[i]
        x,y = x-1,y-1
        G[x].append(y)
        G[y].append(x)
    return G

main()
# print(solve(help(3,[[1,2],[2,3]])))
