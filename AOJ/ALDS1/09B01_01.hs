-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3948648/niruneru/Haskell
import Control.Applicative ((<$>))
import Data.List (intersperse)
import Data.Vector.Unboxed (Vector, (!), (//), fromList, toList, thaw, freeze)
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import Control.Monad ( when, forM_ )
import Control.Monad.ST ( ST, runST )
import Debug.Trace (trace)

main :: IO ()
main = do
  n  <- readLn :: IO Int
  ns <- fromList . (0 :) . map read . words <$> getLine :: IO (Vector Int)
  let maxHeap = runST $ do
        mns <- VU.thaw ns :: ST s (VUM.MVector s Int)
        forM_ [(n `div` 2), (n `div` 2 - 1)..1] $ \i -> maxHeapify i mns
        freeze mns
  putStrLn . (' ' :) . unwords . map show . tail . toList $ maxHeap

maxHeapify :: Int -> VUM.MVector s Int -> ST s ()
maxHeapify i xs = do
  root  <- VUM.read xs i
  let l    = i * 2
      r    = l + 1
      size = VUM.length xs
  case (size > l, size > r) of
    (True, False) ->
      VUM.read xs l >>= \left -> when (left > root) (VUM.swap xs i l >> maxHeapify l xs)
    (False, True) ->
      VUM.read xs r >>= \right -> when (right > root) (VUM.swap xs i r >> maxHeapify r xs)
    (True, True) ->
      VUM.read xs l >>= \left -> VUM.read xs r >>= \right ->
        if left > right then when (root < left) (VUM.swap xs i l >> maxHeapify l xs)
        else when (root < right) (VUM.swap xs i r >> maxHeapify r xs)
    (False, False) -> return ()
