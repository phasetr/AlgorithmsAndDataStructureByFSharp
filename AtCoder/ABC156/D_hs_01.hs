-- https://atcoder.jp/contests/abc156/submissions/14457646
import GHC.Integer.GMP.Internals ( powModInteger, recipModInteger )
main :: IO ()
main = interact $ show . f . map read . words where
  m = 1000000007
  f [n,a,b] = mod (powModInteger 2 n m - 1 - n%a - n%b) m
  f _ = error "not come here"
  n%r = foldl (\x y-> rem (x*y) m) 1 [(n+1-i)*recipModInteger i m | i <- [1..r]]
