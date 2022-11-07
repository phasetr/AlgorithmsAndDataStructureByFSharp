-- https://atcoder.jp/contests/abc107/submissions/10097703
import Data.Array ( array, (!) )
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  x <- map read . words <$> getLine
  print(f n k 1 (array (1,n) (zip [1..n] x)) 1000000000) where
    f n k i x a =
      if n<k+i-1 then a
      else f n k (i+1) x (min a ((\s t->min (abs (s-t)+abs t) (abs (t-s)+abs s)) (x!i) (x!(i+k-1))))
