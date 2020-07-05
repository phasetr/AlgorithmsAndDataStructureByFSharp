-- https://atcoder.jp/contests/abc068/submissions/14183723
main = do
  n <- read <$> getLine
  print . maximum . filter (<= n) $ [2^x | x <- [0..10]]
