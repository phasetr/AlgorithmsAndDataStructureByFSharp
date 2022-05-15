-- https://atcoder.jp/contests/dp/submissions/22882466
import Control.Monad ( join, when, forM_, replicateM )
import Control.Monad.ST ( runST )
import Data.Bits
    ( Bits((.&.), xor, testBit),
      FiniteBits(countLeadingZeros, finiteBitSize) )
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM
import Data.Vector.Generic ((!))

main :: IO ()
main = readLn >>= \n -> replicateM n (get n) >>= print . solve n . V.fromListN n where
  get n = U.unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> V.Vector (U.Vector Int) -> Int
solve n a = runST $ do
  dp <- U.thaw $ U.generate (2^n) g
  forM_ [1..2^n-1] $ join (f dp)
  UM.unsafeRead dp $ 2^n-1
  where
    g s = sum [a!i!j | i <- [0..n-2], testBit s i, j <- [i+1..n-1], testBit s j]
    f v s t = do
      x <- UM.unsafeRead v t
      y <- UM.unsafeRead v (s `xor` t)
      UM.unsafeModify v (max (x+y)) s
      when (testBit t $ lg2 s) $ f v s (s .&. (t-1))

lg2 :: FiniteBits b => b -> Int
lg2 x = finiteBitSize x - countLeadingZeros x - 1
