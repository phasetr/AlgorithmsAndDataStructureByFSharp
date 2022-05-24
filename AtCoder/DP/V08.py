# https://atcoder.jp/contests/dp/submissions/26727167
import sys
sys.setrecursionlimit(10**7)

def main():
    n,m = map(int,input().split())
    edge = [[] for i in range(n)]
    for i in range(n-1):
        a,b = map(int,input().split())
        a,b = a-1,b-1
        edge[a].append(b)
        edge[b].append(a)

    edge[0].append(-1)
    dp1 = [0]*n
    dp2 = [0]*n

    def dfs1(v,p):
        tmp = 1
        edge[v].remove(p)
        for c in edge[v]:
            tmp* = dfs1(c,v)+1
            tmp% = m
        dp1[v] = tmp
        return tmp

    dfs1(0,-1)

    def dfs2(v):
        left = [1]
        for i in edge[v]:
            left.append(left[-1]*(dp1[i]+1)%m)
        right = [1]
        for i in edge[v][::-1]:
            right.append(right[-1]*(dp1[i]+1)%m)
        for i in range(len(edge[v])):
            j = edge[v][i]
            dp2[j] = (((dp2[v]+1)*left[i]%m)*right[-i-2])%m
            dfs2(j)

    dfs2(0)

    for i in range(n):
        print(dp1[i]*(dp2[i]+1)%m)
