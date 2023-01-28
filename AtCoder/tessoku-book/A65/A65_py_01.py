# https://atcoder.jp/contests/tessoku-book/submissions/34911602
def solve(n,P):
    cnt = [0] * n
    for i in range(n-1, 0, -1):
        p = P[i - 1] - 1
        cnt[p] += cnt[i] + 1
    return cnt

def main():
    n = int(input())
    P = list(map(int, input().split()))
    cnt = solve(n,P)
    print(*cnt)

def test():
    n,P = 7,[1,1,3,2,4,4]
    print(solve(n, P))
    n,P = 15,[1,2,1,1,1,6,2,6,9,10,6,12,13,12]
    print(solve(n, P))
