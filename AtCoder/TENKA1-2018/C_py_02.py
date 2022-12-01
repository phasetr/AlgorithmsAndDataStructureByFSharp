# https://atcoder.jp/contests/tenka1-2018/submissions/20056689
import sys

def main():
    N = int(sys.stdin.buffer.readline())
    n = N//2 - 1
    a = sorted(int(x) for x in sys.stdin.buffer.readlines())
    print(2*sum(a[n+2:])-2*sum(a[:n])+a[n+1]-a[n]-N%2*min(a[~n]+a[n],2*a[n+1]))
main()
