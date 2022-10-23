-- https://atcoder.jp/contests/abc142/submissions/20419777
main :: IO ()
main=print.solve.map read.words=<<getLine
solve :: Integral a => [a] -> Int
solve[a,b]=length.f 2$gcd a b
solve _ = error "not come here"
f :: Integral a => a -> a -> [a]
f i x
  |i*i>x=if x==1 then[1]else[x,1]
  |r==0=i:f(i+1)(g i q)
  |otherwise=f(i+1)x
  where(q,r)=divMod x i
g :: Integral t => t -> t -> t
g i x
  |r==0=g i q
  |otherwise=x
  where(q,r)=divMod x i
