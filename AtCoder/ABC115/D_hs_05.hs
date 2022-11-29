-- https://atcoder.jp/contests/abc115/submissions/3770266
import qualified Data.Vector.Unboxed as V
main = do
 [n,x] <- map read . words <$> getLine
 let tv = V.iterateN (n+1) ((+3).(*2)) 1
 let pv = V.iterateN (n+1) ((+1).(*2)) (1::Int)
 print $ f tv pv n x
f tv pv n x
 | x<=0 = 0
 | n==0 = 1
 | x<=(tv V.! n) `div` 2 = f tv pv (n-1) (x-1)
 | otherwise = (pv V.! (n-1)) + 1 + f tv pv (n-1) (x-2-tv V.! (n-1))
