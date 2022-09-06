# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/1727096/ysd2015/Python
import sys

def reconst(pre, ino):
    if len(pre) == 0:
        return
    elif len(pre) == 1:
        print pre[0],
        return

    root = ino.index(pre[0])
    preLeft, preRight = pre[1:root + 1], pre[root + 1:]
    inLeft, inRight = ino[:root], ino[root + 1:]

    reconst(preLeft, inLeft)
    reconst(preRight, inRight)
    print pre[0],

if __name__ == "__main__":
    lines = sys.stdin.readlines()
    pre = map(int, lines[1].split())
    ino = map(int, lines[2].split())
    reconst(pre, ino)
