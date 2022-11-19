-- https://atcoder.jp/contests/abc079/submissions/17852433
import Control.Monad
import Control.Monad.ST
import qualified Data.ByteString.Char8 as C
import Data.Vector.Unboxed ((!))
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = get >>= print . sol

get :: IO (U.Vector Int)
get = U.unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getContents

sol :: U.Vector Int -> Int
sol v = sum [d!(a!k*n+1) | i <- [0..h-1], j <- [0..w-1], let k=i*w+j, a!k>=0, a!k/=1] where
  (h,w,c,a) = (v!0, v!1, U.unsafeSlice 2 m v,U.drop (2+m) v)
  d = warshallFloyd n c

n = 10
m = n*n

warshallFloyd :: (Ord a, Num a, UM.Unbox a) => Int -> U.Vector a -> U.Vector a
warshallFloyd n c = runST $ do
  d <- U.unsafeThaw c
  let
    ix i j = i*n+j
    putw i j w = UM.unsafeWrite d (ix i j) w
    getw i j = UM.unsafeRead d (ix i j)
  forM_ [0..n-1] $ \k ->
    forM_ [0..n-1] $ \i ->
      forM_ [0..n-1] $ \j -> do
        a <- getw i k
        b <- getw k j
        p <- getw i j
        putw i j (min p (a+b))
  U.unsafeFreeze d
