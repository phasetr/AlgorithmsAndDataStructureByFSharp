# https://atcoder.jp/contests/tessoku-book/submissions/38501351
def solve(n,q,s,ia):
    mod = 998244353
    L = [0]
    R = [0]
    for i in range(n): L.append((L[-1]*100+(ord(s[i])-96))%mod)
    for i in range(n-1, -1, -1): R.append((R[-1]*100+(ord(s[i])-96))%mod)

    res = []
    for i,(l,r) in enumerate(ia):
        x = (L[r]-L[l-1]*pow(100, r-l+1, mod)) % mod
        y = (R[-l]-R[-(r+1)]*pow(100, r-l+1, mod)) % mod
        res.append("Yes" if x==y else "No")
    return res

n, q = map(int, input().split())
s = input()
for r in solve(n,q,s,[map(int,input().split()) for _ in q]):
    print(r)

def test():
    print(-1%1000)

    n,q,s,ia = 11,3,"mississippi",[(5,8),(6,10),(2,8)]
    print(ord("a"))
    print(ord(s[0]-96))
    print(solve(n,q,s,ia))

    n,q,s,ia = 100000,13,"".join(["a"]*100000),[(4,99998),(5,99991),(11,99991),(8,99992),(7,99993),(11,99992),(5,99995),(2,99999),(7,99995),(2,99993),(6,99997),(4,99996),(1,99998)]
    print(solve(n,q,s,ia) == ['Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes','Yes'])

    n,q,s,ia = 10,5,"aaaaaaaaaa",[(1,10),(2,9),(3,8),(4,7),(5,6)]
    print((solve(n, q, s, ia)))

