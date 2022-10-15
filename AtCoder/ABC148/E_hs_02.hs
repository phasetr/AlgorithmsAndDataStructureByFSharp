-- https://atcoder.jp/contests/abc148/submissions/13411405
main :: IO ()
main = do
  n <- readLn
  print $ if odd n then 0 else sum . map (n `div`) . takeWhile (<= n) $ map (\i -> 2*5^i) [1..]
