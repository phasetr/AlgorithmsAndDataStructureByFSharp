import Data.Function ((&))
import qualified Data.IntMap as M

-- https://atcoder.jp/contests/code-festival-2017-qualb/submissions/1667256
solve dsOrig tsOrig = if b then "YES" else "NO"
  where
    ds = dsOrig & foldl (\m di -> M.insertWith (+) di 1 m) M.empty
    ts = tsOrig & foldl (\m ti -> M.insertWith (+) ti (-1) m) ds
    b = 0 <= minimum (M.elems ts)

main :: IO()
main = do
  n <- read <$> getLine :: IO Int
  ds <- map read . words <$> getLine :: IO [Int]
  m <- read <$> getLine :: IO Int
  ts <- map read . words <$> getLine :: IO [Int]
  print $ solve ds ts
