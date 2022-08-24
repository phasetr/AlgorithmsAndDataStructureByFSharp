{-
See ../../AOJ/ALDS1/06C01_mvec.hs
-}
import Control.Monad ( when, forM_ )
import Data.STRef ( newSTRef, readSTRef, writeSTRef )
import Control.Monad.ST ( ST, runST )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

qsort1 :: Ord a => [a] -> V.Vector a
qsort1 as = runST $ do
  let n = V.length av
  amv <- V.thaw av
  qsortM amv 0 (n-1)
  V.freeze amv
  where
    av = V.fromList as
    qsortM :: Ord a => VM.MVector s a -> Int -> Int -> ST s ()
    qsortM amv p r =
      when (p < r) $ do
        (amv, q) <- partition amv p r
        qsortM amv p (q-1)
        qsortM amv (q+1) r
    partition :: Ord a => VM.MVector s a -> Int -> Int -> ST s (VM.MVector s a, Int)
    partition amv p r = do
      x <- VM.read amv r
      i <- newSTRef (p-1)
      forM_ [p..r-1] $ \j -> do
        y <- VM.read amv j
        when (y<=x) $ do
          i0 <- readSTRef i
          writeSTRef i (i0+1)
          VM.swap amv (i0+1) j
      i0 <- readSTRef i
      VM.swap amv (i0+1) r
      return (amv, i0+1)

main :: IO ()
main = do
  print $ qsort1 [3,2,1]
  print $ qsort1 [3,4,2,1]
