module Insertion where
import Data.List ( insert )
{-
Insertion sort
https://riptutorial.com/haskell/example/7551/insertion-sort
https://stackoverflow.com/questions/28550361/insertion-sort-in-haskell
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/1/ALDS1_1_A
See also ../../AOJ/ALDS1/01A01.hs
-}
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

main :: IO ()
main = do
  print $ isort1 [5,4,3,2,1] == [1,2,3,4,5]
  print $ isort1 [1..3] == [1..3]
  print $ isort2 [5,4,3,2,1] == [1,2,3,4,5]
  print $ isort2 [1..3] == [1..3]
