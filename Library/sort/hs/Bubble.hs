{-
See ../../AOJ/ALDS1/02D01.hs
選択ソートとの比較: 安定ソートか否か
-}
module Bubble where
import Control.Monad ( when, forM_ )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Control.Monad.ST ( runST )

-- https://qiita.com/7shi/items/1e2a66bf8e8c7f0bd70f
bsort1 :: Ord a => [a] -> [a]
bsort1 [] = []
bsort1 xs = y : bsort1 ys where (y:ys) = bswap xs

bswap :: Ord a => [a] -> [a]
bswap []  = []
bswap [x] = [x]
bswap (x:xs)
  | x > y     = y:x:ys
  | otherwise = x:y:ys
  where (y:ys) = bswap xs

bsort2 :: Ord a => Int -> V.Vector a -> V.Vector a
bsort2 n av = runST $ do
  amv <- V.thaw av
  forM_ [0..(n-2)] $ \i -> do
    forM_ [0..(n-i-2)] $ \j -> do
      aj <- VM.read amv j
      aj1 <- VM.read amv (j+1)
      when (aj1 < aj) $ do
        VM.write amv j aj1
        VM.write amv (j+1) aj
  V.freeze amv

main :: IO ()
main = do
  print $ bswap [4,3,1,5,2] == [1,4,3,2,5]
  print $ bswap [4,3,2,5]   == [2,4,3,5]
  print $ bswap [4,3,5]     == [3,4,5]
  print $ bsort1 [4,3,1,5,2] == [1..5]
  print $ bsort1 [5,4,3,2,1] == [1..5]
  print $ bsort1 [4,6,9,8,3,5,1,7,2] == [1..9]
  print $ bsort2 5 (V.fromList [4,3,1,5,2]) == V.fromList [1..5]
  print $ bsort2 5 (V.fromList [5,4,3,2,1]) == V.fromList[1..5]
  print $ bsort2 9 (V.fromList [4,6,9,8,3,5,1,7,2]) == V.fromList [1..9]
