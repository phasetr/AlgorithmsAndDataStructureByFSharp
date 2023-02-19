-- https://atcoder.jp/contests/tessoku-book/submissions/37931351
main :: IO ()
main = interact $ show . sol . read

sol n = n `div` 3 + n `div` 5 + n `div` 7 - n `div` 15 - n `div` 21  - n `div` 35 + n `div` 105
