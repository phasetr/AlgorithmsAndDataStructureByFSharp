-- https://atcoder.jp/contests/abc156/submissions/25143420
main :: IO()
main = (getLine >> getLine) >>= (print . solve . map read . words)

solve :: [Int] -> Int
solve xs = minimum $ map (step xs) [1..pMax] where
  step xs p = foldl (\acc x -> acc + (x-p)^2 ) 0 xs
  pMax = 100
