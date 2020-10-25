# # Special Pythagorean triplet
# - [URL](https://projecteuler.net/problem=9)
# ## Problem 9
# A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
# $a^2 + b^2 = c^2$.
# For example, 32 + 42 = 9 + 16 = 25 = 52.
# There exists exactly one Pythagorean triplet for which a + b + c = 1000.
# Find the product abc.
#
# ピタゴラスの三つ組みは $a < b < c$ かつ $a^2 + b^2 = c^2$ をみたす 3 つの自然数の集合を指す。
# ここで $a+b+c=1000$$ をみたす三つ組みはただ1つしかない。
# このときの積 $abc$ を求めよ。

def solve(n):
    for a in range(1, n + 1):
        for b in range(a, n + 1):
            c = n - a - b
            if a**2 + b**2 == c**2:
                print(a, b, c)
                print(a * b * c)


solve(1000)
