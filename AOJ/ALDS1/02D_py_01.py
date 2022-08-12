def insertion_sort(A, N, step):
    count = 0
    for i in range(step,N):
        v = A[i]
        j = i - step
        while j >= 0 and A[j]>v:
            A[j+step] = A[j]
            j -= step
            count += 1
        A[j+step] = v
    return count

def solve(N,A):
    m = int.bit_length(N)
    G = [N//(2**i) for i in range(m)]
    count = sum(insertion_sort(A, N, G[i]) for i in range(m))
    return (m,G,count,A)

def main():
    N = int(input())
    A = [int(input()) for _ in range(N)]
    (m,G,count,A) = solve(N,A)
    print(m)
    print(*G)
    print(count)
    print(*A, sep="\n")

main()

def test():
    print(solve(5,[5,1,4,3,2]))
