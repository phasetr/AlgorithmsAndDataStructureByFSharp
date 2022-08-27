# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2472165/jakenu0x5e/Python3
from math import sqrt
q3 = sqrt(3)
fmt = "%.8f %.8f"
def koch(x0, y0, x1, y1, c):
    if c == n:
        return (fmt % (x0, y0),)
    xp = (x0*2 + x1) / 3
    yp = (y0*2 + y1) / 3

    xq = (x0 + x1*2) / 3
    yq = (y0 + y1*2) / 3

    dx = (x1 - x0) / 6
    dy = (y1 - y0) / 6

    xr = xp + (dx - dy * q3)
    yr = yp + (dx * q3 + dy)

    return koch(x0, y0, xp, yp, c+1) + koch(xp, yp, xr, yr, c+1) + koch(xr, yr, xq, yq, c+1) + koch(xq, yq, x1, y1, c+1)
n = int(input())
print(*koch(0, 0, 100, 0, 0)+(fmt % (100, 0),), sep='\n')
