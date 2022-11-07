-- https://atcoder.jp/contests/code-festival-2016-qualc/submissions/9690081
main = do
  getLine; a <- map read . words <$> getLine
  print $ max (maximum a* 2 - sum a - 1) 0
