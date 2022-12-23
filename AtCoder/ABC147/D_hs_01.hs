-- https://atcoder.jp/contests/abc147/submissions/20680155
import Data.Bits
    ( Bits(testBit, bit),
      FiniteBits(countLeadingZeros, finiteBitSize) )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main =
  readLn >>=
  (\n -> V.unfoldrN n (B.readInt . B.dropWhile (==' ')) <$> B.getLine) >>=
  print . solve
solve :: (FiniteBits b, V.Unbox b, Ord b) => V.Vector b -> Int
solve as = V.foldl' (f as) 0 $ V.enumFromN 0 (let a=V.maximum as in finiteBitSize a-countLeadingZeros a)
f :: (V.Unbox a, Bits a) => V.Vector a -> Int -> Int -> Int
f as s i = (\(j,k) -> mod (mod (j*k) m * mod (bit i) m+s) m)
  $ V.foldl' (\(j,k) a -> if testBit a i then (j+1,k) else (j,k+1)) (0,0) as
  where m = 10^9+7
