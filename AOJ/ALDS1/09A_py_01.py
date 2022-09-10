# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/3185036/jakenu0x5e/Python3
N = int(input())
*A, = map(int, input().split())
for i in range(N):
    R = ["node %d: key = %d," % (i+1, A[i])]
    l = 2*i+1; r = 2*i+2
    if i:
        R.append("parent key = %d," % A[(i-1)//2])
    if l < N:
        R.append("left key = %d," % A[l])
    if r < N:
        R.append("right key = %d," % A[r])
    print(*R, "")
