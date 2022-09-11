# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2046783/leafmoon/Python3
from heapq import *
import sys
q=[]
while True:
    a=sys.stdin.readline().split()
    if a[0]=='end': break
    if a[0]=='insert':
        heappush(q,-int(a[1]))
    else:
        print(-heappop(q))
