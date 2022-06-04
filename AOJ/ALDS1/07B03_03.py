# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/3185385/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
writelines = sys.stdout.writelines

def tree(N,xss):
    L = [None]*N
    R = [None]*N
    S = [-1]*N
    P = [-1]*N
    Deg = [0]*N
    for i in range(N):
        i,l,r = xss[i]
        L[i] = l; R[i] = r
        if l != -1:
            P[l] = i
            Deg[i] += 1
        if r != -1:
            P[r] = i
            Deg[i] += 1
        if l != -1 != r:
            S[l] = r; S[r] = l
    return (L,R,S,P,Deg)

def height_depth(L,R,P):
    D = [-1]*N
    H = [-1]*N
    def dfs(v,d):
        D[v] = d
        H[v] = h = max((dfs(L[v],d+1) if L[v] != -1 else 0), (dfs(R[v],d+1) if R[v] != -1 else 0))
        return h+1
    dfs(P.index(-1),0)
    return (D,H)

def solve(N,xss):
    L,R,S,P,Deg = tree(N, xss)
    D,H = height_depth(L, R, P)

    def node_type(pi,dgi):
        if pi == -1:
            return "root"
        elif dgi == 0:
            return "leaf"
        else:
            return "internal node"

    retval = []*N
    for i in range(N):
        retval.append([i,P[i],S[i],Deg[i],D[i],H[i],node_type(P[i],Deg[i])])

    return retval

def main():
    N = int(readline())
    xss = []
    for i in range(N):
        i, l, r = map(int, readline().split())
        xss.append([i,l,r])
    print(solve(N,xss))
    writelines(["node %d: parent = %d, sibling = %d, degree = %d, depth = %d, height = %d, %s\n" % (i, P[i], S[i], Deg[i], D[i], H[i], 'root' if P[i] == -1 else 'leaf' if Deg[i] == 0 else 'internal node') for i in range(N)])

N = 9
xss = [
    [0,1,4],
    [1,2,3],
    [2,-1,-1],
    [3,-1,-1],
    [4,5,8],
    [5,6,7],
    [6,-1,-1],
    [7,-1,-1],
    [8,-1,-1]]
print(tree(N,xss) == ([1,2,-1,-1,5,6,-1,-1,-1],
                      [4,3,-1,-1,8,7,-1,-1,-1],
                      [-1,4,3,2,1,8,7,6,5],
                      [-1,0,1,1,0,4,5,5,4],
                      [2,2,0,0,2,2,0,0,0]))
(L,R,S,P,Deg) = tree(N, xss)
print(height_depth(L,R,P) == ([0,1,2,2,1,2,3,3,2],[3,1,0,0,2,1,0,0,0]))
print(solve(N,xss) == [
    [0,-1,-1,2,0,3,"root"],
    [1,0,4,2,1,1,"internal node"],
    [2,1,3,0,2,0,"leaf"],
    [3,1,2,0,2,0,"leaf"],
    [4,0,1,2,1,2,"internal node"],
    [5,4,8,2,2,1,"internal node"],
    [6,5,7,0,3,0,"leaf"],
    [7,5,6,0,3,0,"leaf"],
    [8,4,5,0,2,0,"leaf"]])
n = 5
xss = [
    [3,4,0],
    [4,-1,-1],
    [1,-1,-1],
    [2,-1,-1],
    [0,1,2]]
print(solve(n,xss) == [
    [0,3,4,2,1,1,'internal node'],
    [1,0,2,0,2,0,'leaf'],
    [2,0,1,0,2,0,'leaf'],
    [3,-1,-1,2,0,2,'root'],
    [4,3,0,0,1,0,'leaf']])
