# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/1665561/ikki407/Python
n = int(raw_input())
Pre = map(int,raw_input().split())
In = map(int,raw_input().split())

idx = 0

def reconstruction(l,r):
    global idx
    if l >= r:
        return
    c = Pre[idx]
    idx += 1
    m = In.index(c)
    reconstruction(l,m)
    reconstruction(m+1,r)

    print c,

def main():
    reconstruction(0,n)
    print
    return 0

main()
