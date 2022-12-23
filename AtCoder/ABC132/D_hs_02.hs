-- https://atcoder.jp/contests/abc132/submissions/19529567
import GHC.Integer.GMP.Internals ( recipModInteger )
import qualified Data.Vector.Unboxed as V
main :: IO ()
main = V.mapM_ print . solve . (\[n,k] -> (n,k)) . map read . words =<< getLine
solve :: (Int, Int) -> V.Vector Int
solve (n,k) = V.generate k f where
  fact = V.scanl'(*%) 1 $ V.generate n (+1)
  ifact = V.scanr' (*%) (fromInteger $ recipModInteger (toInteger $ V.last fact) (toInteger m)) $ V.generate n (+1)
  c n k = fact V.! n *% ifact V.! k *% ifact V.!(n-k)
  h n k = c (n+k-1) k
  f i = if n-k<i then 0 else c (k-1) i *% h (i+2) (n-k-i)
infixl 7 *%
a *%b = mod (a*b) m
m = 10^9+7::Int
