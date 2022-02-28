{-
https://atcoder.jp/contests/abc117/tasks/abc117_c
入力はすべて整数である。
1 \leq N \leq 10^5
1 \leq M \leq 10^5
-10^5 \leq X_i \leq 10^5
X_1, X_2, ..., X_M は全て異なる。
-}

import Data.List
main :: IO()
main = do
  [n,m] <- map read . words <$> getLine :: IO [Int]
  xs <- map read . words <$> getLine :: IO [Int]
  print $ solve n m xs

-- https://atcoder.jp/contests/abc117/submissions/23517625
solve :: Int -> Int -> [Int] -> Int
solve n m xs =
  sum . take (m-n) . sort $ zipWith (-) (tail ys) (init ys)
  where ys = sort xs

test :: IO()
test = do
  let (n,m,xs) = (2,5,[10,12,1,2,14])
  print $ solve n m xs == 5
  let (n,m,xs) = (3,7,[-10,-3,0,9,-100,2,17])
  print $ solve n m xs == 19
  let (n,m,xs) = (100,1,[-100000])
  print $ solve n m xs == 0
