-- https://atcoder.jp/contests/abc051/submissions/24941243{-
main :: IO ()
main = interact
  $show . solve . map read . words

solve :: (Enum a, Ord a, Num a) => [a] -> Int
solve [k,s] = length [1 | x <- [0..k] , y <- [0..k],
                  0<=s-x-y && s-x-y<=k]
solve _ = error "undefined"
