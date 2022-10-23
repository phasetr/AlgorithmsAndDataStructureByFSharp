-- https://atcoder.jp/contests/abc142/submissions/9857049
import Data.List ( nub )
main :: IO ()
main = do
  [a,b]<-map read.words<$>getLine
  let x=gcd a b
  print$(1+)$length$nub$f 2 x
f :: Integral a => a -> a -> [a]
f p x
 |x==1=[]
 |p*p>x=[x]
 |x`mod`p==0=p:f p(div x p)
 |otherwise=f(p+1)x
