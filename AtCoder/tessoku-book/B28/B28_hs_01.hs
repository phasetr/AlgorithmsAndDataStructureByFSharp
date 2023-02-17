-- https://atcoder.jp/contests/tessoku-book/submissions/37914867
main :: IO ()
main = readLn >>= print . sol

sol :: Int -> Int
sol = fst . f (0, 1) where
  f pq@(p, q) n
    | n==0      = (0, 1)
    | even n    = f ((`mod` m) $ p^2+q^2, (`mod` m) $ 2*p*q+q^2) (n `div` 2)
    | otherwise = tpq pq $ f pq (n-1)
  tpq (p, q) (a, b) = ((`mod` m) $ p*a+q*b, (`mod` m) $ q*a+(p+q)* b)
  m = 10^9+7
