-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/2908991/lvs7k/Haskell
import Control.Monad ( when, forM_ )
import qualified Data.ByteString.Char8 as B
import Data.Array.IO
    ( newListArray,
      readArray,
      writeArray,
      MArray(getBounds),
      IOUArray )
import Data.Array.MArray
    ( newListArray, readArray, writeArray, MArray(getBounds) )
import Data.Maybe ( fromJust )

(!?) :: IOUArray Int Int -> Int -> IO (Maybe Int)
a !? i = do
  (_, t) <- getBounds a
  if i < 1 || t < i then return Nothing else fmap Just (readArray a i)

swap :: Int -> Int -> IOUArray Int Int -> IO ()
swap x y a = do
  vx <- readArray a x
  vy <- readArray a y
  writeArray a y vx
  writeArray a x vy

maxHeapify :: Int -> IOUArray Int Int -> IO ()
maxHeapify i a = do
  let l = i * 2
  let r = i * 2 + 1
  vi <- readArray a i
  mleft <- a !? l
  mright <- a !? r
  let t1 = case mleft of
        Nothing -> i
        Just vl
          | vl > vi -> l
          | otherwise -> i
  vt1 <- readArray a t1
  let t2 = case mright of
        Nothing -> t1
        Just vr
          | vr > vt1 -> r
          | otherwise -> t1
  when (t2 /= i) $ do
    swap i t2 a
    maxHeapify t2 a

buildMaxHeap :: IOUArray Int Int -> IO ()
buildMaxHeap a = do
  (_, e) <- getBounds a
  let e' = e `div` 2
  forM_ [e', e'-1 .. 1] $ \i -> do
    maxHeapify i a

main :: IO ()
main = do
  n <- readLn
  xs <- fmap ((-1 :) . fmap (fst . fromJust . B.readInt) . B.words) B.getLine
  ary <- newListArray (0, n) xs :: IO (IOUArray Int Int)
  buildMaxHeap ary
  forM_ [1 .. n] $ \i -> do
    v <- readArray ary i
    putStr $ " " ++ show v
  putStrLn ""
