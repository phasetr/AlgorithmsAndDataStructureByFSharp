-- https://atcoder.jp/contests/abc115/submissions/17146340
import Data.Bits ( Bits(shift) )
main :: IO ()
main = print . (\[n,x] -> f n x) . map read . words =<< getLine
f 0 x = min 1 x
f n x
  | x <=n = 0
  | x<k+2 = f (n-1) (x-1)
  | otherwise = (k+1) `div` 2 + 1 + f (n-1) (x-k-2)
  where k = shift 1 (n+1)-3
