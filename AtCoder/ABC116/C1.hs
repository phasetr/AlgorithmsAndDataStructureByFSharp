-- https://atcoder.jp/contests/abc116/submissions/9848360
main :: IO()
main = do
  n <- read <$> getLine :: IO Int
  xs <- map read . words <$> getLine :: IO [Int]
  print $ solve xs

solve = f 0
  where
    f acc [] = 0
    f acc (h:hs) = max (h-acc) 0 + f h hs
