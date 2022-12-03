-- https://atcoder.jp/contests/abc099/submissions/9848419
main :: IO ()
main = do
  n <- readLn
  print $ minimum [f i 6 + f (n-i) 9 | i <- [0..n]]

f :: Integral p => p -> p -> p
f 0 k = 0
f n k = mod n k + f (div n k) k
