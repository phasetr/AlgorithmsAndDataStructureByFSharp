-- https://atcoder.jp/contests/abc114/submissions/4017100
main :: IO ()
main = readLn >>= print . solve

solve :: Int -> Int
solve n = go 0 False False False where
  go c s f t
    | c > n     = 0
    | otherwise = (if s&&f&&t then 1 else 0)
      + go (10*c+7) True f t
      + go (10*c+5) s True t
      + go (10*c+3) s f True
