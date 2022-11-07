-- https://atcoder.jp/contests/agc011/submissions/1165590
import Data.List ( sort )
f :: (Ord a, Num a, Num t) => a -> t -> [a] -> t
f x n [] = n
f x n (a:as)
  | a <= x*2 = f (x+a) (n+1) as
  | otherwise = f (x+a) 1 as
main :: IO ()
main = do
  getLine
  as <- sort . map read . words <$> getLine
  print $ f 0 0 (sort as)
