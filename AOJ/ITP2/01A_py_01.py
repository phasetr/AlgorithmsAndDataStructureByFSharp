# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/5017994/mohejin/Python3
q=int(input())
a=[]
for i in range(q):
    com=list(map(int,input().split()))
    if com[0]==0:
        a.append(com[1])
    elif com[0]==1:
        print(a[com[1]])
    else: a.pop()
