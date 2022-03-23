-- https://atcoder.jp/contests/arc059/submissions/11983527
main :: IO ()
main = getLine >> getLine
  >>= print . solve . map read . words
solve :: [Int] -> Int
solve as = minimum [sum $ map ((^2) . (b -)) as | b <- [-100..100]]
