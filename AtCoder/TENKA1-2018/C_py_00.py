def solve(N,A):
    A.sort()
    ans = 0
    if N%2==0:
        ans = 2*sum(A[N//2:])-2*sum(A[:N//2])-A[N//2]+A[N//2-1]
    else:
        ans = 2*(sum(A[N//2+1:])-sum(A[:N//2]))+max(A[N//2]-A[N//2+1],A[N//2-1]-A[N//2])
    return ans

N = int(input())
A = [int(input()) for i in range(N)]
solve(N,A)

solve(5,[6,8,1,2,3]) == 21
solve(6,[3,1,4,1,5,9]) == 25
solve(3,[5,5,1]) == 8

N = 5
A = [6,8,1,2,3]
A.sort()
N%2==0
2*sum(A[N//2:])-2*sum(A[:N//2])-A[N//2]+A[N//2-1]
A[N//2:]
A[:N//2]
2*(sum(A[N//2+1:])-sum(A[:N//2]))+max(A[N//2]-A[N//2+1],A[N//2-1]-A[N//2])
A[N//2+1:]
A[N//2]
A[N//2+1]
A[N//2-1]
A[N//2]
