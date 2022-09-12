from sys import stdin

def solve(N,A):
    A.sort()
    for i in range(1, N):
        j = i-1
        while j>0:
            k = (j-1)//2
            A[j], A[k] = A[k], A[j]
            j = k
        A[0], A[i] = A[i], A[0]
    return A

def main():
    N = int(stdin.readline().rstrip())
    A = list(map(int, stdin.readline().rstrip().split()))
    print(*solve(N,A))
main()

def test():
    N = 8
    A  = [1,2,3,5,9,12,15,23]
    print(solve(N,A) == [23,9,15,2,5,3,12,1])
test()
