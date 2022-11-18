-- https://atcoder.jp/contests/abc108/submissions/8561611
main :: IO ()
main = do
  [n, k] <- map read . words <$> getLine
  print $ (n `div` k) ^ 3 + if even k then ((n + k `div` 2) `div` k) ^ 3 else 0
