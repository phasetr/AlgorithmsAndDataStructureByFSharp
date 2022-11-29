-- https://atcoder.jp/contests/abc115/submissions/3745513
main :: IO ()
main = interact $ show . (\[n,x] -> f n x) . map read . words
f 0 1 = 1
f _ 1 = 0
f n x
  | x == t = (2^(n+1))-1
  | x == t-1 = (2^(n+1))-1
  | x == m = 2^n
  | x < m = f (n-1) (x-1)
  | otherwise = (2^n) + f (n-1) (x-m)
  where
    t = (2^(n+2))-3
    m = (t `div` 2) + 1
