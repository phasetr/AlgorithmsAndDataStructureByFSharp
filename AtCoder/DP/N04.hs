-- https://atcoder.jp/contests/dp/submissions/20276677
{-# LANGUAGE FlexibleContexts #-}
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import Data.Vector.Generic ((!))

main :: IO ()
main = readLn >>= \n -> get n >>= print . solve n where
  get n = U.unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> U.Vector Int -> Int
solve n a = dp!(n-1)!0 where
  b = U.scanl' (+) 0 a
  dp = V.constructN n f :: V.Vector (U.Vector Int)
  f v
    | V.null v  = U.replicate n 0
    | otherwise = U.generate (n-i) g
    where
      i = V.length v
      g l = minimum (h <$> [0..i-1])+b!(l+i+1)-b!l
        where h j = v!j!l+v!(i-1-j)!(l+j+1)
