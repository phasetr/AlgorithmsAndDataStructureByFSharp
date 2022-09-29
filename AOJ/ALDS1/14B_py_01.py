# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/5153361/vjudge2/Python3
# scanf
text = str(input())
pattern = str(input())

# index
for i in range(len(text)):
    if text.startswith(pattern, i):
        print(i)
