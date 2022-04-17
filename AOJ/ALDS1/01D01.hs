-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_D
import Data.List ( tails )
main :: IO ()
main = getLine >> getContents >>= print . solve . map read . words
solve :: [Int] -> Int
solve xs = maximum $ zipWith (-) (tail xs) (scanl1 min xs)

test :: IO ()
test = do
  print $ tails xs1
  print $ tail xs1
  print $ scanl1 min xs1
  print $ solve xs1 == 3
  print $ solve [3,4,3,2] == 1
  where
    xs1 = [5,3,1,3,4,3]
