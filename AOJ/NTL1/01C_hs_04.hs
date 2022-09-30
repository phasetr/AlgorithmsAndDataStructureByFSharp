-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/1717589/s1190170/Haskell
main :: IO ()
main = do
  n <- getLine
  a <- fmap (map (read :: String -> Int) . words) getLine
  print $ foldl lcm 1 a
