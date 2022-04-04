-- https://atcoder.jp/contests/abc061/submissions/9848321
import Data.List (sort)
main :: IO ()
main = do
  [n,k] <- map read . words <$>getLine
  ab <- sort . map (map read . words) . lines <$> getContents
  print $ f k ab

f :: (Ord p, Num p) => p -> [[p]] -> p
f k ([a,b]:ab)
  | k>b = f (k-b) ab
  | otherwise = a
f _ _ = undefined
