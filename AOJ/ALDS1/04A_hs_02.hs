-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/2301438/a143753/Haskell
import Data.List ( intersect, nub )
solve :: [Int] -> [Int] -> Int
solve s q = length $ nub $ intersect s q

main :: IO ()
main = do
  getLine
  s <- fmap (map read . words) getLine
  getLine
  q <- fmap (map read . words) getLine
  print $ solve s q
