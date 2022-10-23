-- https://atcoder.jp/contests/abc130/submissions/17322582
solve :: Int -> Int -> Int -> Int -> [Int] -> [Int] -> Int
solve n k s i [] _ = 0
solve n k s i _ [] = 0
solve n k s i (a:as) (b:bs)
  | s+b >= k = (n-i) + solve n k (s-a) i as (b:bs)
  | otherwise = solve n k (s+b) (i+1) (a:as) bs

main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine :: IO [Int]
  as <- map read . words <$> getLine :: IO [Int]
  print $ solve n k 0 0 as as
