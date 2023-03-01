-- https://atcoder.jp/contests/tessoku-book/submissions/35857988
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( intersperse )
import Data.IORef ( newIORef, readIORef, writeIORef )
import System.IO.Unsafe ( unsafePerformIO )
import Data.Maybe ( fromJust )

import Data.Array ( (!), accumArray )
import qualified Data.IntSet as IS

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
  let ans = tbb62 n m abs
  putStrLn $ foldr ($) "" $ intersperse (' ' :) $ map shows ans

tbb62 :: Int -> Int -> [(Int,Int)] -> [Int]
tbb62 n m abs = loop IS.empty [[n]] where
  g = accumArray (flip (:)) [] (1,n) [p | (a,b) <- abs, p <- [(a,b),(b,a)]]
  loop _ (is@(1:_) : _) = is
  loop vs (is@(k:_) : iss)
    | IS.member k vs = loop vs iss
    | otherwise = loop (IS.insert k vs) $ foldr (:) iss [j:is | j <- g ! k]
  loop _ _ = error "not come here"

test :: IO ()
test = do
  let (n,m) = (5,4)
  let abs = [(1,2),(2,3),(3,4),(3,5)]
  let g = accumArray (flip (:)) [] (1,n) [p | (a,b) <- abs, p <- [(a,b),(b,a)]]
  print g
