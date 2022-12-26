-- https://atcoder.jp/contests/tessoku-book/submissions/36771385
main :: IO ()
main = getLine >>= print . sol . (\[n,k] -> (n,k)) . map read . words

sol :: Integral a => (a, a) -> a
sol (n,k) = f (n-1) (k-3)

f :: Integral a => a -> a -> a
f n k
  | k <= n    = g (k+1)
  | k <= 2*n  = g (k+1) - 3*g (k-n)
  | k <= 3*n  = g (3*n-k+1)
  | otherwise = 0
  where g k = k*(k+1) `div` 2
