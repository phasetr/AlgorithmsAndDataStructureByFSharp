# https://atcoder.jp/contests/dp/submissions/31804949
import sys
sys.setrecursionlimit(10**9)
nr,nc = [int(x) for x in input().split()]
boxes = [input() for i in range(nr)]
modder = 10**9+7

paths = [[-1 for j in range(nc+1)] for i in range(nr+1)]
for row in range(-1,nr):
    for col in range(-1,nc):
        if row == -1 or col == -1:
            val = 0
        elif row == 0 and col == 0:
            val = 1
        elif boxes[row-1][col] == '.':
            if boxes[row][col-1] == '.':
                val = paths[row-1][col]+paths[row][col-1]
            else:
                val = paths[row-1][col]
        else:
            if boxes[row][col-1] == '.':
                val = paths[row][col-1]
            else:
                val = 0
    paths[row][col] = val
print(paths[nr-1][nc-1]%modder)
