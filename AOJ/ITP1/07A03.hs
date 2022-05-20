-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_A/review/1693454/amusan39/Haskell
main :: IO ()
main = getContents >>= putStr . unlines
  . map (solve . map read . words) . init . lines
solve :: (Num a, Ord a) => [a] -> String
solve [a,b,c]
  | a == -1 || b == -1 || a + b < 30 = "F"
  | a + b >= 80 = "A"
  | a + b >= 65 = "B"
  | a + b >= 50 = "C"
  | a + b >= 30 = if c >= 50 then "C" else "D"
solve _ = error "undefined"
