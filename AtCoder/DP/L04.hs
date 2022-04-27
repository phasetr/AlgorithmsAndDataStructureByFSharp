-- https://atcoder.jp/contests/dp/submissions/19876051
import Control.Monad ( forM_ )
import Control.Monad.ST ( ST, runST )
import Data.Array.ST ( readArray, writeArray, MArray(newArray), STUArray )
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = readLn >>= \n -> get n >>= print . solve n where
  get t = U.unfoldrN t (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> U.Vector Int -> Int
solve n a = runST $ do
  dp <- newArray ((1,1),(n,n)) 0 :: ST s (STUArray s (Int,Int) Int)
  forM_ [1..n] $ \i -> writeArray dp (i,i) (a!(i-1))
  forM_ [1..n-1] $ \k -> do
    forM_ [1..n-k] $ \i -> do
      let j=k+i
      l <- readArray dp (i+1,j)
      r <- readArray dp (i,j-1)
      writeArray dp (i,j) $ max (a!(i-1)-l) (a!(j-1)-r)
  readArray dp (1,n)
