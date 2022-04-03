-- https://atcoder.jp/contests/abc128/submissions/5741340
import Control.Monad (guard,forM_,replicateM)

main = do
  [n, m] <- map read . words <$> getLine
  ks <- map (tail . map read . words) <$> replicateM m getLine :: IO [[Int]]
  ps <- map read . words <$> getLine :: IO [Int]
  print $ solve n ks ps

solve :: Int -> [[Int]] -> [Int] -> Int
solve n ks ps = sum $ do
  t <- replicateM n [0,1]
  forM_ (zip ks ps) $ \(s, p) -> do
    guard $ (sum (map ((t !!) . subtract 1) s) `rem` 2) == p
  return 1
