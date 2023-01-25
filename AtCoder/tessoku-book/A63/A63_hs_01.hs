-- https://atcoder.jp/contests/tessoku-book/submissions/35858847
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.IORef ( newIORef, readIORef, writeIORef )
import System.IO.Unsafe
import Data.Maybe ( fromJust )

import Data.Array ( (!), accumArray )
import qualified Data.IntMap as IM

{-# NOINLINE jio #-}
jio = unsafePerformIO (BS.getContents >>= newIORef)
jioInt :: IO Int
jioInt = readIORef jio >>= closing . fromJust . BS.readInt . BS.dropWhile isSpace
  where closing (x,co) = writeIORef jio co >> return x

main :: IO ()
main = do
  n <- jioInt
  m <- jioInt
  abs <- replicateM m $ do
    a <- jioInt
    b <- jioInt
    return (a,b)
  let ans = tba63 n m abs
  mapM_ print ans

tba63 :: Int -> Int -> [(Int,Int)] -> [Int]
tba63 n m abs = [IM.findWithDefault (-1) i m | i <- [1..n]] where
  g = accumArray (flip (:)) [] (1,n) [p | (a,b) <- abs, p <- [(a,b),(b,a)]]
  m = loop IM.empty (IM.singleton 1 0)
  -- m : 頂点の1からの距離, d : vsの距離, vs : 新たに訪問する頂点
  loop m vs
    | IM.null vs = m
    | otherwise  = loop m1 vs1
    where
      m1 = IM.union m vs
      d1 = succ $ head $ IM.elems vs
      vs1 = IM.fromList [(w, d1) | v <- IM.keys vs, w <- g ! v, IM.notMember w m1]
