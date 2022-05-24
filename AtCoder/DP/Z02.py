# https://atcoder.jp/contests/dp/submissions/9784249
def solve(N,C,hs):
    ls = [(-2*hs[0], hs[0]**2)] + [0]*N
    I,J = 0,0
    for h in hs[1:]:
        u, v = ls[I]
        while I<J:
            w, y = ls[I+1]
            if u*h+v < w*h+y:
                break
            u, v, I = w, y, I+1
        a, b = -2*h, u*h+v+2*h**2+C
        while J:
            (c, d), (e, f) = ls[J], ls[J-1]
            if (c-e)*(b-d) < (d-f)*(a-c):
                break
            J-=1
        J+=1
        ls[J] = (a, b)
    return (u*h+v + h**2+C)

def main():
    N, C = map(int, input().split())
    hs = list(map(int, input().split()))
    print(solve(N,C,hs))

def test():
    print(solve(5,6,[1,2,3,4,5]) == 20)
test()
