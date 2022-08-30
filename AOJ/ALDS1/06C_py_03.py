# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/3185059/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline

def partition(A, p, r):
    x = A[r]
    i = p
    for j in range(p, r):
        if A[j][1] <= x[1]:
            A[i], A[j] = A[j], A[i]
            i += 1
    A[i], A[r] = A[r], A[i]
    return i

def quicksort(A, p, r):
    if p < r:
        q = partition(A, p, r)
        quicksort(A, p, q-1)
        quicksort(A, q+1, r)

def solve(N,A,D):
    D = {k: iter(v).__next__ for k, v in D.items()}
    quicksort(A, 0, N-1)
    ok = 1
    for v, d in A:
        if D[d]() != v:
            ok = 0
    ans = ['Stable' if ok else 'Not stable']
    for v, d in A:
        ans.append("%s %d" % (v, d))
    return ans

def main():
    N = int(input())
    A = []
    D = {}
    for i in range(N):
        v, d = readline().split()
        A.append((v, int(d)))
        D.setdefault(int(d), []).append(v)
    print("\n".join(solve(N,A,D)))

def test():
    N = 6
    A = [("D",3),("H",2),("D",1),("S",3),("D",2),("C",1)]
    D = {1:['D','C'], 2:['H','D'], 3:['D','S']}
    # print(solve(N,A,D))
    print(solve(N,A,D) == ["Not stable","D 1","C 1","D 2","H 2","D 3","S 3"])
    # print("\n".join(solve(N,A,D)))
    N = 2
    A = [("S",1),("H",1)]
    D = {1:["S","H"]}
    print(solve(N,A,D) == ['Stable','S 1','H 1'])
test()
