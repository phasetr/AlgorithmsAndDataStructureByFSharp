-- https://atcoder.jp/contests/jsc2019-qual/submissions/9943827
main :: IO ()
main=do
  [n,k]<-map(read::String->Integer).words<$>getLine
  a<-map(read::String->Integer).words<$>getLine
  let mo=10^9+7::Integer
  let kk=k*(k-1)`div`2`mod`mo
  print$(`mod`mo)$sum[mod(kk*cnt+t*k)mo|(b,i)<-zip a[0..],let cnt=toInteger$length$filter(>b)a,let t=toInteger$length$filter(>b)$take i a]
