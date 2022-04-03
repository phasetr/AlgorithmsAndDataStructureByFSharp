-- https://atcoder.jp/contests/abc146/submissions/24972050
solve :: Int -> Int -> Int -> Int -> Int -> Int
solve a b x lo hi
  | hi - lo <= 1 = mid
  | res > x = solve a b x lo mid
  | otherwise = solve a b x mid hi
  where
    mid = (lo + hi) `div` 2
    d = length $ show mid
    res = a * mid + b * d

main :: IO ()
main = do
  [a, b, x] <- map read . words <$> getLine
  let n = 10 ^ 9
  print $ if x >= a * n + b * 10
          then n
          else solve a b x 0 n
