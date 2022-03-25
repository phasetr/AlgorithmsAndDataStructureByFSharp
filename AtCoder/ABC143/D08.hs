{-
https://atcoder.jp/contests/abc143/submissions/17593582
-}
import Data.List (sort)

solveSub :: Int -> [Int] -> [Int] -> Int -> Int -> Int
solveSub a [] _ m n = 0
solveSub a _ [] m n = 0
solveSub a (x:xs) (y:ys) m n
  | (a + x) > y = n - m + solveSub a (x:xs) ys m (n + 1)
  | m + 1  == n = solveSub a (x:xs) ys m (n + 1)
  | otherwise = solveSub a xs (y:ys) (m + 1) n

solve :: [Int] -> Int
solve [] = 0
solve (a:s) = solveSub a s (tail s) 0 1 + solve s

main :: IO ()
main = do
  n <- readLn :: IO Int
  ls <- sort . map read . words <$> getLine :: IO [Int]
  print $ solve ls
