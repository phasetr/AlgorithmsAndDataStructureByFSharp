-- https://atcoder.jp/contests/panasonic2020/submissions/15871639
main = interact $ unlines . s . read
s 1 = ["a"]
s n = [x++[c] | x<-s $ n-1, c<-['a'..succ $ maximum x]]
