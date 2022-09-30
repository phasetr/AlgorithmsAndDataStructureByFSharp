-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/2834173/a143753/Haskell
k :: Integer
k = 1000000007

ans :: Integral a => Integer -> a -> Integer
ans m 0 = 1
ans m 1 = m
ans m n =
  let n' = n `div` 2
      x  = ans m n'
      y  = ans m (n-2*n')
  in (x * x * y) `mod` k

main :: IO ()
main = do
  l <- getLine
  let (m:n:_) = map read $ words l :: [Integer]
      o = ans m n
  print o
