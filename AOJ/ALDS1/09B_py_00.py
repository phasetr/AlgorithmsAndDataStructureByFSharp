# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3185025/jakenu0x5e/Python3
def heapify(i,N,A):
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
        heapify(l,N,A)
    elif right:
        A[i], A[r] = A[r], A[i]
        heapify(r,N,A)

def solve(N,A):
    for i in range(N-1, -1, -1):
        heapify(i,N,A)
    return A

def main():
    N = int(input())
    *A, = map(int, input().split())
    for i in range(N-1, -1, -1):
        heapify(i,N,A)
    print("",*A)

print(solve(10,[4,1,3,2,16,9,10,14,8,7]) == [16,14,10,8,7,9,3,2,4,1])
