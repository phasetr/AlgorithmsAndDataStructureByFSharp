-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_A/review/2210391/aimy/Haskell
main = interact $ unlines . map itp1_7_a . read' . lines
  where read' = map (map read . words) . takeWhile (/= "-1 -1 -1")

itp1_7_a [m,f,r]
  | m == (-1) || f == (-1) = "F"
  | m+f >= 80 = "A"
  | m+f >= 65 = "B"
  | m+f >= 50 = "C"
  | m+f >= 30 = if r >= 50 then "C" else "D"
  | otherwise = "F"
itp1_7_a _ = error "undefined"
