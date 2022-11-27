# https://atcoder.jp/contests/abc075/submissions/7505963
n,m = map(int, input().split())
e = [list(map(int, input().split())) for _ in range(m)]
c = 0
for x in e:
    l = list(range(n))
    for y in e:
        if y!=x:
            l = [l[y[0]-1] if l[i]==l[y[1]-1] else l[i] for i in range(n)]
    if len(set(l))!=1:
        c+=1
print(c)
