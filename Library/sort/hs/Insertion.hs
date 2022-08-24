{-
Insertion sort
https://riptutorial.com/haskell/example/7551/insertion-sort
https://stackoverflow.com/questions/28550361/insertion-sort-in-haskell
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/1/ALDS1_1_A
See also ../../AOJ/ALDS1/01A01.hs, ../../AOJ/ALDS1/01A02.hs
-}
module Insertion where
import Control.Monad ( forM_ )
import Control.Monad.ST ( runST )
import Data.List ( insert )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
isort1 :: Ord a => [a] -> [a]
isort1 [] = []
isort1 (x:xs) = insert $ isort1 xs where
  insert [] = [x]
  insert (y:ys)
    | x < y = x : y : ys
    | otherwise = y : insert ys

-- https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Shell_sort#Haskell
-- Insertion sort, for sorting columns.
isort2 :: Ord a => [a] -> [a]
isort2 = foldr insert []

isort3 :: Ord a => Int -> V.Vector a -> V.Vector a
isort3 n av = runST $ do
  amv <- V.thaw av
  forM_ [1..n-1] (\i -> do
                     let j = i-1
                     v <- VM.read amv i
                     j <- while amv j v
                     VM.write amv (j+1) v)
  V.freeze amv
  where
    while av j v = do
      if j < 0 then return j
      else do
        u <- VM.read av j
        if u <= v then return j
        else do
          VM.write av (j+1) u
          while av (j - 1) v

main :: IO ()
main = do
  print $ isort1 [5,4,3,2,1] == [1..5]
  print $ isort1 [1..3] == [1..3]
  print $ isort2 [5,4,3,2,1] == [1..5]
  print $ isort2 [1..3] == [1..3]
  print $ isort3 5 (V.fromList [5,4,3,2,1]) == V.fromList [1..5]
  print $ isort3 3 (V.fromList [1..3]) == V.fromList [1..3]
