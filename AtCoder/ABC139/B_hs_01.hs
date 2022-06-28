-- https://atcoder.jp/contests/abc139/submissions/17894630
main :: IO ()
main = do
  [a,b] <- map read.words<$>getLine
  print $ ceiling $ (b-1)/(a-1)
