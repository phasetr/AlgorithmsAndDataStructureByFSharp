{-
https://atcoder.jp/contests/code-festival-2017-qualb/tasks/code_festival_2017_qualb_b
1 \leq N \leq 200,000
1 \leq D_i \leq 10^9
1 \leq M \leq 200,000
1 \leq T_i \leq 10^9
入力される値は全て整数である
-}
--import Data.Function ((&))
import Data.List (sort)
solve :: [Int] -> [Int] -> String
solve ds ts = if sort ts `subseq` sort ds then "YES" else "NO"
  where
    subseq [] _ = True
    subseq _ [] = False
    subseq (x : xs) (y : ys)
      | x == y = xs `subseq` ys
      | otherwise = (x : xs) `subseq` ys

main :: IO()
main = do
  n <- read <$> getLine :: IO Int
  ds <- map read . words <$> getLine :: IO [Int]
  m <- read <$> getLine :: IO Int
  ts <- map read . words <$> getLine :: IO [Int]
  print $ solve ds ts

test = do
  print $ solve [3,1,4,1,5] [5,4,3] == "YES"
  print $ solve [100,200,500,700,1200,1600,2000] [100,200,500,700,1600,1600] == "NO"
  print $ solve [800] [100,100,100,100,100] == "NO"
  print $ solve  [1,2,2,3,3,3,4,4,4,4,5,5,5,5,5] [5,4,3,2,1,2,3,4,5] == "YES"
