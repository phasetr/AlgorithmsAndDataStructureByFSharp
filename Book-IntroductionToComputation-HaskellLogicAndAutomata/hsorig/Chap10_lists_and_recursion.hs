-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 10 : Lists and Recursion

module Chap10_lists_and_recursion where

import Chap05_lists_and_comprehensions (squares)

import Test.QuickCheck (quickCheck)

-- Recursive function definitions

squaresRec :: [Int] -> [Int]
squaresRec []     = []
squaresRec (x:xs) = x*x : squaresRec xs

squaresCond :: [Int] -> [Int]
squaresCond ws =
  if null ws then []
  else x*x : squaresCond xs
    where x  = head ws
          xs = tail ws

squares_prop :: [Int] -> Bool
squares_prop ns =
    squares ns == squaresRec ns && squares ns == squaresCond ns

qc1 = quickCheck squares_prop

-- More recursive function definitions

oddsRec :: [Int] -> [Int]
oddsRec []                 = []
oddsRec (x:xs) | odd x     = x : oddsRec xs
               | otherwise = oddsRec xs

-- The following function definitions are commented out because they are already in the Prelude.
-- You can hide those definitions to allow them to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (sum, product, and, or)

-- sum :: [Int] -> Int
-- sum []     = 0
-- sum (x:xs) = x + sum xs

-- product :: [Int] -> Int
-- product []     = 1
-- product (x:xs) = x * product xs

-- and :: [Bool] -> Bool
-- and []     = True
-- and (x:xs) = x && and xs

-- or :: [Bool] -> Bool
-- or []     = False
-- or (b:bs) = b || or bs

sumSqOddsRec :: [Int] -> Int
sumSqOddsRec []                 = 0
sumSqOddsRec (x:xs) | odd x     = x*x + sumSqOddsRec xs
                    | otherwise = sumSqOddsRec xs

-- Sorting a list

-- parameter list is in ascending order; same for result list
insert :: Int -> [Int] -> [Int]
insert m []                 = [m]
insert m (n:ns) | m <= n    = m:n:ns
                | otherwise = n : insert m ns

insertionSort :: [Int] -> [Int]
insertionSort []     = []
insertionSort (n:ns) = insert n (insertionSort ns)

l1 = insertionSort [4,8,2,1,7,17,2,3]

quicksort :: [Int] -> [Int]
quicksort []     = []
quicksort (m:ns) = quicksort less ++ [m] ++ quicksort more
                     where less = [ n | n <- ns, n < m ]
                           more = [ n | n <- ns, n >= m ]

l2 = quicksort [4,8,2,1,7,17,2,3]

sort_prop :: [Int] -> Bool
sort_prop ns = insertionSort ns == quicksort ns

qc2 = quickCheck sort_prop

-- parameter list is in ascending order; same for result list
insert' :: Ord a => a -> [a] -> [a]
insert' m []                 = [m]
insert' m (n:ns) | m <= n    = m:n:ns
                 | otherwise = n : insert' m ns

insertionSort' :: Ord a => [a] -> [a]
insertionSort' []     = []
insertionSort' (n:ns) = insert' n (insertionSort' ns)

quicksort' :: Ord a => [a] -> [a]
quicksort' []     = []
quicksort' (m:ns) = quicksort' less ++ [m] ++ quicksort' more
                      where less = [ n | n <- ns, n < m ]
                            more = [ n | n <- ns, n >= m ]

l3 = insertionSort' ["elephant","zebra","gnu","buffalo","impala"]

l4 = quicksort' ["hippopotamus","giraffe","hippo","lion","leopard"]

-- Exercise 6

insertionSort'' :: Ord a => [a] -> [a]
insertionSort'' []     = []
insertionSort'' (n:ns) = insertionSort'' (insert' n ns)
