-- https://atcoder.jp/contests/dp/submissions/20429173
import Control.Monad ( when, forM_ )
import Control.Monad.ST ( runST )
import Data.Bits ( Bits(clearBit, popCount, testBit) )
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM
import Data.Vector.Unboxed ((!))

main :: IO ()
main = readLn >>= \n -> get (n^2) >>= print . solve n where
  get t = U.unfoldrN t (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve :: (UM.Unbox a, Num a, Eq a) => Int -> U.Vector a -> Int
solve n a = runST $ do
  dp <- UM.replicate (2^n) 0
  UM.write dp 0 1
  forM_ [1..2^n-1] $ \s -> do
    let i = popCount s-1
    forM_ [0..n-1] $ \j -> when (testBit s j && a!(i*n+j)==1) $ do
      c <- UM.unsafeRead dp (clearBit s j)
      UM.unsafeModify dp ((`mod` p) . (c +)) s
  UM.unsafeRead dp (2^n-1)

p = 10^9+7 :: Int
