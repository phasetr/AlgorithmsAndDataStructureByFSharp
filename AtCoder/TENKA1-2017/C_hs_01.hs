-- https://atcoder.jp/contests/tenka1-2017/submissions/9552113
main :: IO ()
main = interact $ unwords . map show . head . f . read
f :: Integral a => a -> [[a]]
f n= [[x,y,div m d] | x<-q, y<-q, let d=4*x*y-n*x-n*y, let m=n*x*y, d>0, mod m d<1]
  where q = [1..3500]
