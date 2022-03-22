{-
https://atcoder.jp/contests/abc065/submissions/17184936
-}
main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  print $ solve n m

solve :: Int -> Int -> Int
solve n m
  | abs (n - m) >= 2 = 0
  | otherwise = ((factrialM n * factrialM m) `mod` (10^9 + 7) * engagement) `mod` modnum
  where
    modnum = 10^9 + 7
    engagement = if n == m then 2 else 1
    factrialM :: Int -> Int
    factrialM n = foldl (\a b -> a * b `mod` modnum) 1 [1..n]
