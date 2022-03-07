{-
https://atcoder.jp/contests/arc081/submissions/9846913
-}
import Data.List
main :: IO ()
main = do
  n <- read <$> getLine
  xs <- map read . words <$> getLine
  print $ solve n xs

solve :: (Num a, Ord a) => a -> [a] -> a
solve n xs =
  if length x>=2 then product $ take 2 x else 0
  where
    x = (reverse . sort . f . sort) xs
    f (a:b:s)
      | a==b = a:f s
      | otherwise = f $ b:s
    f _ = []

test :: IO ()
test = do
  print $ solve 6 [3,1,2,4,2,1] == 2
  print $ solve 4 [1,2,3,4] == 0
  print $ solve 10 [3,3,3,3,4,4,4,5,5,5] == 20
  print $ solve 6 [1,1,4,4,4,4] == 16
