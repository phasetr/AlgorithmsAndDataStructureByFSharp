-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/19239170
main :: IO ()
main = interact
  $ f . (\[n,m,k] -> (n,m,k)) . map read . words

f :: (Num a, Enum a, Eq a) => (a, a, a) -> [Char]
f (n,m,k) = last
  $ "No" : ["Yes" | x <- [0..n], y <- [0..m],
            x*(m-y)+(n-x)*y==k]
