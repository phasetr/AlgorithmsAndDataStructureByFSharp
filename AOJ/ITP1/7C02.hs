-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/2211338/aimy/Haskell
import Data.List (transpose)
main :: IO ()
main = interact
  $ unlines . map (unwords . map show)
  . solve . map (map read . words) . tail . lines
solve :: [[Integer]] -> [[Integer]]
solve =
  transpose . map addsum . transpose . map addsum
  where addsum ns = ns ++ [sum ns]
