-- https://atcoder.jp/contests/abc147/submissions/15084036
import Control.Monad ( forM )

main = do
  n  <- read <$> getLine
  xy <- forM [1 .. n] $ \i -> do
    a <- read <$> getLine
    forM [1 .. a] $ \j -> do
      [x, y] <- map read . words <$> getLine
      return (x, y)
  print $ solve n xy

solve :: Int -> [[(Int, Int)]] -> Int
solve n xy = maximum $ map sum $ filter (ok 0) $ masks n where
  masks 0 = [[]]
  masks n = do
    m <- masks $ n - 1
    [0 : m, 1 : m]
  ok i mask
    | i == n    = True
    | otherwise = (mask !! i == 0 || all ok2 (xy !! i)) && ok (succ i) mask
    where ok2 (x, y) = mask !! (x - 1) == y
