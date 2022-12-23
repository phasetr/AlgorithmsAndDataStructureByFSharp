-- https://atcoder.jp/contests/abc132/submissions/6181056
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  mapM_ print $ [ans (n-k) k i | i <- [1..k]]

ans :: Integer -> Integer -> Integer -> Integer
ans r b i = if r < i-1 then 0
  else ((b-1) `c` (i-1)) * ((r+1) `c` i) `mod` 1000000007

c :: Integer -> Integer -> Integer
c n 0 = 1
c n k = (`mod` 1000000007) $ product [n-k+1..n] `div` product [1..k]
