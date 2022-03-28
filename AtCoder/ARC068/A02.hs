-- https://atcoder.jp/contests/arc068/submissions/25084530
main :: IO ()
main = readLn >>= print
  . (\x -> x `quot` 11*2 + quot (rem x 11+5) 6)
