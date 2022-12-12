-- https://atcoder.jp/contests/abc140/submissions/7415000
main :: IO ()
main = interact $ show . f . words

f :: (Num a, Read a, Ord a) => [String] -> a
f [n,k,s] = read n - max (g s-2*read k) 1
f _ = error "not come here"

g :: (Num p, Eq a) => [a] -> p
g (x:y:l) = sum [1 | x/=y] + g (y:l)
g _=1
