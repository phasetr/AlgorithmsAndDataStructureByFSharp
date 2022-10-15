-- https://atcoder.jp/contests/abc127/submissions/9857651
import Data.List ( sort )
main :: IO ()
main = do
  getLine
  a<-map(negate.read).words<$>getLine
  bc<-map((\[b,a]->(-a,b)).map read.words).lines<$>getContents
  let x=sort$bc++zip a(repeat 1)
  print$negate$f x(length a)

f :: (Ord a, Num a) => [(a, a)] -> a -> a
f((a,c):x)t
  |t>c=a*c+f x(t-c)
  |otherwise=a*t
f _ _ = error "not come here"
