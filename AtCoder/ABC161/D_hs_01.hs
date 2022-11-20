-- https://atcoder.jp/contests/abc161/submissions/16303119
main :: IO ()
main = readLn >>= print . (a!!) . pred
  where a = [1..9]++(a >>= (\n -> map (10*n+) [max (n `mod` 10 - 1) 0..min(n `mod` 10+1) 9]))
