-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/2212480/aimy/Haskell
main = getLine
  >>= print
  . (\[x1,y1,x2,y2]-> sqrt $ (x2-x1)^2 + (y2-y1)^2)
  . map read . words
