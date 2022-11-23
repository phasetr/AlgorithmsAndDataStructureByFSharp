-- https://atcoder.jp/contests/abc112/submissions/3412682
main :: IO ()
main = do
  (n:m:_) <- map read . words <$> getLine
  print $ sol n m

sol :: Integer -> Integer -> Integer
sol n m = div m $ minimum $ filter (>=n) $ divs m

divs :: Integer -> [Integer]
divs = d 1 where
  d k m
    | k^2>m = []
    | mod m k ==0 = k : div m k : d (k+1) m
    | otherwise   = d (k+1) m
