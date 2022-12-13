-- https://atcoder.jp/contests/abc090/submissions/3108580
main = do
  (n:k:_) <- map read . words <$> getLine
  print $ if k==0 then n*n else sum.map (\b-> (b-k) * (n `div` b) + max ((n `mod` b)-k+1) 0) $ [k+1..n]
