-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_B/review/2211313/aimy/Haskell
main = interact
  $ unlines . map (show . solve . map read . words)
  . init . lines

solve [n,x] = length
  [(a1,a2,a3) |
   a1<-[1..n],
   a2<-[1..n],
   a3<-[1..n],
   (a1<a2) && (a2<a3),
   a1+a2+a3==x]
solve _ = error "undefined"
