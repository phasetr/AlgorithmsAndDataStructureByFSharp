-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_5_C
import Data.List
main = interact
  $ unlines . map (cb . map read . words) . init . lines
cb :: [Int] -> String
cb [h,w] = unlines $ take h $ map (take w) $ tails $ cycle "#."
cb _ = error "undefined"
