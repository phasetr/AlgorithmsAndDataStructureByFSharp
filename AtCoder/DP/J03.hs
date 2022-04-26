-- https://atcoder.jp/contests/dp/submissions/19746571
import Control.Monad ( forM_, when )
import Control.Monad.ST ( runST, ST )
import Data.Array ( Ix, accumArray, elems )
import Data.Array.ST ( readArray, writeArray, MArray(newArray), STUArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )

main :: IO ()
main = solve <$> readLn <*> get >>= print where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve :: (Ix i, Num i) => Int -> [i] -> Double
solve n as = runST $ do
  dp <- newArray ((-1,-1,-1),(c1+1,c2+1,c3+1)) 0 :: ST s (STUArray s (Int,Int,Int) Double)
  forM_ [0..c3] $ \k -> do
    forM_ [0..c2-k] $ \j -> do
    forM_ [0..c1-k-j] $ \i -> do
    when (i+j+k>0) $ do
    e1 <- readArray dp (i-1,j,  k  )
    e2 <- readArray dp (i+1,j-1,k  )
    e3 <- readArray dp (i,  j+1,k-1)
    writeArray dp (i,j,k) ((f n+f i*e1+f j*e2+f k*e3)/f (i+j+k))
  readArray dp (b1,b2,b3)
  where
    b@[b1,b2,b3] = elems . accumArray (+) 0 (1,3) $ zip as (repeat 1)
    [c1,c2,c3] = scanr1 (+) b
    f = fromIntegral
