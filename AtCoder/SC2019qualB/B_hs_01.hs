-- https://atcoder.jp/contests/jsc2019-qual/submissions/7170968
main = interact $ show.f.map read.words;f(n:k:l)=foldl(&)0$[k*(k-1)`div`2|x<-l,y<-l,x>y]++[k | i<-[0..n-1],z<-drop i l,l!!i>z];x&y=rem(x+y)1000000007
