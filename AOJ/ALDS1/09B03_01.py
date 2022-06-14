# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3185025/jakenu0x5e/Python3
N = int(input())
*A, = map(int, input().split())
def heapify(i):
    l = 2*i+1; r = 2*i+2
    left = l < N and A[i] < A[l]
    right = r < N and A[i] < A[r]
    if left and right:
        if A[l] < A[r]:
            left = 0
        else:
            right = 0
    if left:
        A[i], A[l] = A[l], A[i]
        heapify(l)
    elif right:
        A[i], A[r] = A[r], A[i]
        heapify(r)


for i in range(N-1, -1, -1):
    heapify(i)
print("",*A)
