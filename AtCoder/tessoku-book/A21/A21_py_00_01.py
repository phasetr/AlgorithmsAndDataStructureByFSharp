# https://atcoder.jp/contests/tessoku-book/submissions/36746499
def solve(N,T):
    D = eval('[0]*(N+2),'*(N+2))
    B = lambda k: N>k>=0 and (l<=T[k][0]<=r)*T[k][1]
    for l in range(1,N+1):
        for r in range(N,0,-1):
            D[l][r] = max(D[l][r+1]+B(r), D[l-1][r]+B(l-2))
    return max(D[i][i]for i in range(N))

def main():
    (N,),*T = [[*map(int,t.split())] for t in open(0)]
    return solve(N,T)

main()

# test
print(solve(4,[[4,20],[3,30],[2,20],[1,10]]) == 50)
print(solve(8,[[8,100],[7,100],[6,100],[5,100],[4,100],[3,100],[2,100],[1,100]]) == 400)
