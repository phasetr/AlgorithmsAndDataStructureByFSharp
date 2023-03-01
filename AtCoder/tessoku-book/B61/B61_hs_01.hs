-- https://atcoder.jp/contests/tessoku-book/submissions/35828896
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.IORef ( newIORef, readIORef, writeIORef )
import System.IO.Unsafe ( unsafePerformIO )
import Data.Maybe ( fromJust )

import Data.Array ( accumArray, assocs )

{-# NOINLINE jio #-}
jio = unsafePerformIO (BS.getContents >>= newIORef)

closing :: (b, BS.ByteString) -> IO b
closing (x,co) = writeIORef jio co >> return x
flipPair :: (b, a) -> (a, b)
flipPair (x,y) = (y,x)

-- 整数をひとつ読み込み
jioInt :: IO Int
jioInt = readIORef jio >>= closing . fromJust . BS.readInt . BS.dropWhile isSpace

main :: IO ()
main = do
  n <- jioInt
  m <- jioInt
  abs <- replicateM m $ do
    a <- jioInt
    b <- jioInt
    return (a,b)
  let ans = tbb61 n m abs
  print ans

tbb61 :: Int -> Int -> [(Int,Int)] -> Int
tbb61 n m abs = snd $ maximum [(b,a) | (a,b) <- assocs cs] where
  cs = accumArray (+) 0 (1,n)
       [p | (a,b) <- abs, p <- [(a,1), (b,1)]]
