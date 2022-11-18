-- https://atcoder.jp/contests/abc108/submissions/3118600
main = do
  (n:k:_) <- map read . words <$> getLine
  print $ sol n k
--
sol :: Integral a => a -> a -> a
sol n k
  | odd k = (n `div` k)^3
  | otherwise = (n `div` k)^3 + ((n + (k `div` 2)) `div` k)^3
