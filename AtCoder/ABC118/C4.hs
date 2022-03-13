{-
https://atcoder.jp/contests/abc118/submissions/9848341
-}
main=getLine>>getLine>>=print.foldl1 gcd.map read.words
