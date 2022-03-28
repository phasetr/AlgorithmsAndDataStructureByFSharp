-- https://atcoder.jp/contests/arc068/submissions/1085353
main :: IO ()
main = readLn >>=
  print . (\x -> x`div`11*2 + (x`mod`11+5)`div`6)
