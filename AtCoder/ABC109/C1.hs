{-
https://atcoder.jp/contests/abc109/tasks/abc109_c

- 入力はすべて整数である
- 1 \leq N \leq 10^5
- 1 \leq X \leq 10^9
- 1 \leq x_i \leq 10^9
- x_i はすべて異なる
- x_1, x_2, ..., x_N \neq X
-}

import Data.Function ((&))
main :: IO()
main = do
  [_,x] <- map read . words <$> getLine :: IO [Int]
  xs <- map read . words <$> getLine :: IO [Int]
  print $ solve x xs

solve :: Int -> [Int] -> Int
solve x xs = xs & map (\xi -> abs (x-xi)) & foldl1 gcd

test :: IO()
test = do
  print $ 2 == solve 3 [1,7,11]
  print $ 24 == solve 81 [33,105,57]
  print $ 999999999 == solve 1 [1000000000]
