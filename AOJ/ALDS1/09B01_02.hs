-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3367267/showzaemon/Haskell
import qualified Data.Sequence as S
import qualified Data.ByteString.Char8 as B
import Data.Array.IO
    ( getElems, newListArray, readArray, writeArray, IOUArray )
import Data.Maybe ( fromJust )
import qualified Data.Map as M

main :: IO()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine
  l <- fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine
  r <- solve n l
  print' r
print' :: [Int] -> IO()
print' [] = putStrLn ""
print' (x:xs) = do
    putStr $ ' ':show x
    print' xs

solve :: Int -> [Int] -> IO [Int]
solve n l = iter (newListArray (0, n) (minBound:l)) (div n 2) where
    iter :: IO (IOUArray Int Int) -> Int -> IO [Int]
    iter ar 0 = fmap (drop 1) (ar >>= getElems)
    iter ar i = iter (maxHeapify ar i) (i-1) where
      maxHeapify ar i = do
        a <- ar
        iv <- readArray a i
        lv <- readArray a l
        rv <- readArray a r
        if iv > lv
        then if iv > rv then return a else swap a i iv r rv
        else if lv > rv then swap a i iv l lv else swap a i iv r rv where
          swap :: IOUArray Int Int -> Int -> Int -> Int -> Int -> IO (IOUArray Int Int)
          swap a i iv m mv = do
            writeArray a i mv
            writeArray a m iv
            maxHeapify (return a) m
          l = if 2*i <= n then 2*i else 0
          r = if 0 < l && l < n then l+1 else 0
