-- https://atcoder.jp/contests/tessoku-book/submissions/38273620
main :: IO ()
main = sol <$> readLn >>= print

sol n = f 0 1 n where
  f a _ 0 = a
  f a d p = f (a + r*(1 + n `mod` d) + d*(s (r-1) + q*s9)) (10*d) q
    where (q,r) = quotRem p 10
  s n = n*(n+1) `div` 2
  s9 = s 9
