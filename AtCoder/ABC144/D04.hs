-- https://atcoder.jp/contests/abc144/submissions/9856954
main :: IO ()
main = getLine >>=
  print . solve . (\[a,b,x] -> (a,b,x)) . map read . words

solve :: RealFloat a => (a, a, a) -> a
solve (a,b,x) = (57.2958*)
  $ flip atan2 (a/b) $ if 1<z then 2-z else 1/z
  where z = 2*x/a/a/b
