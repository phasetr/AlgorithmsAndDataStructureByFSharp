-- https://atcoder.jp/contests/arc068/submissions/12021969
main = readLn >>= print.solve
solve x
  | r == 0 = 2*q
  | r <= 6 = 2*q + 1
  | otherwise = 2*q + 2
  where (q, r) = divMod x 11
