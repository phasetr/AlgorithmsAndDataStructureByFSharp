{-# LANGUAGE RankNTypes #-}
import Control.Monad.ST
import Control.Monad
import Control.Monad.Primitive (PrimMonad, PrimState)
import Data.STRef
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Data.List (sortOn)
import Prelude hiding (read)

partitionFirst :: Ord a => VM.MVector s a -> Int -> Int -> ST s Int
partitionFirst mv l r = do
  p <- VM.read mv l
  i <- newSTRef (l+1)
  forM_ [l+1..(r-1)] $ \j -> do
    mvj <- VM.read mv j
    i'  <- readSTRef i
    when (mvj < p) $ do
      VM.swap mv i' j
      modifySTRef' i (+1)
  i' <- readSTRef i
  VM.swap mv (i'-1) l
  return (i'-1)

partitionLast :: Ord a => VM.MVector s a -> Int -> Int -> ST s Int
partitionLast mv l r = do
    VM.swap mv (r-1) l
    partitionFirst mv l r

partitionMedian :: Ord a => VM.MVector s a -> Int -> Int -> ST s Int
partitionMedian mv l r = do
    p <- chooseMedian mv l r
    VM.swap mv p l
    partitionFirst mv l r

chooseMedian :: (PrimMonad m, Ord a) => VM.MVector (PrimState m) a -> Int -> Int -> m Int
chooseMedian mv l r = do
  h <- VM.read mv l
  t <- VM.read mv (r-1)
  let len = r-l
  let mid = if even len
            then l + (len `div` 2) - 1
            else l + (len `div` 2)
  m <- VM.read mv mid
  let options = sortOn snd [(l, h), (mid, m), (r-1, t)]
  return (fst (options !! 1))

qsort mv start end partition comparisons = when (start < end) $ do
  i <- partition mv start end
  modifySTRef' comparisons (+ (end-start-1))
  qsort mv start i   partition comparisons
  qsort mv (i+1) end partition comparisons

qsortM :: Ord a => V.Vector a -> (forall s a. (Ord a) => VM.STVector s a -> Int -> Int -> ST s Int) -> Int
qsortM v partition = runST $ do
  mv <- V.thaw v
  comps <- newSTRef 0
  qsort mv 0 (V.length v) partition comps
  readSTRef comps

test = do
  let v = V.fromList [3,2,1]
  print $ qsortM v partitionFirst
  print $ qsortM v partitionLast
  print $ qsortM v partitionMedian
  print v
