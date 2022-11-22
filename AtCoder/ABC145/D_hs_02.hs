-- https://atcoder.jp/contests/abc145/submissions/19010290
import GHC.Integer.GMP.Internals ( recipModInteger )
main :: IO ()
main = print . solve . map read . words =<< getLine
solve :: [Int] -> Int
solve [x,y] = if a<0||c/=0||b<0||d/=0 then 0 else r where
  [(a,c),(b,d)] = map (`quotRem`3) [2*y-x,2*x-y]
  k = min a b
  f i j = foldr (*%) 1 [i..j]
  r = f (a+b-k+1) (a+b) *% fromInteger (recipModInteger (toInteger $ f 1 k) (toInteger m))
  a *%b = rem (a*b) m
  m = 10^9+7::Int
solve _ = error "not come here"
