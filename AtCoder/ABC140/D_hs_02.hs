-- https://atcoder.jp/contests/abc140/submissions/16510638
main :: IO ()
main = do
  [n, k] <- map read . words <$> getLine
  ds <- getContents
  let s = length . filter id . (zipWith (==) <$> id <*> tail) $ ds
  print $ (s + 2 * k) `min` (n - 1)
