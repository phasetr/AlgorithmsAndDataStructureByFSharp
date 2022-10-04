-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_B/review/4798845/mencotton/Haskell
main :: IO ()
main = do
  [a, b] <- fmap (map read . words) getLine
  print (a-b)
