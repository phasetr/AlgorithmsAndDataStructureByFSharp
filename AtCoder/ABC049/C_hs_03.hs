-- https://atcoder.jp/contests/abc049/submissions/25639280
main=do s<-reverse<$>getLine;putStr$ f s
f "" = "YES"
f ('m':'a':'e':'r':'d':ns) = f ns
f ('r':'e':'m':'a':'e':'r':'d':ns) = f ns
f ('e':'s':'a':'r':'e':ns) = f ns
f ('r':'e':'s':'a':'r':'e':ns) = f ns
f _ = "NO"
