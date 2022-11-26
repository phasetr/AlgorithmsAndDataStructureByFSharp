-- https://atcoder.jp/contests/diverta2019/submissions/5357440
main :: IO ()
main = readLn >>= \n ->
  print (sum [n `div` r - 1 | r <- [1..1000000], r*(r+1) < n, n `mod` r == 0])
