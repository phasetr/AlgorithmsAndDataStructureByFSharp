-- https://atcoder.jp/contests/tessoku-book/submissions/35451993
main :: IO ()
main = do
  [n, k] <- map read . words <$> getLine
  print $ length [0 | a <- [1 .. n], b <- [1 .. n], let c = k - a - b, 1 <= c && c <= n]
