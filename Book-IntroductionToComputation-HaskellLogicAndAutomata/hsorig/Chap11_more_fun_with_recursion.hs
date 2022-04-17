-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 11 : More Fun with Recursion

module Chap11_more_fun_with_recursion where

import Chap05_lists_and_comprehensions (isPrime)

-- Counting

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (enumFromTo)

-- enumFromTo :: Int -> Int -> [Int]
-- enumFromTo m n | m > n  = []
--                | m <= n = m : enumFromTo (m+1) n

prodFromTo :: Int -> Int -> Int
prodFromTo m n | m > n  = 1
               | m <= n = m * prodFromTo (m+1) n

factorial :: Int -> Int
factorial n = prodFromTo 1 n

-- Infinite lists and lazy evaluation

-- The following function definitions are commented out because they are already in the Prelude.
-- You can hide those definitions to allow them to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (enumFrom, head, tail)

-- enumFrom :: Int -> [Int]
-- enumFrom m = m : enumFrom (m+1)

-- head :: [a] -> a
-- head []      = error "empty list"
-- head (x : _) = x

-- tail :: [a] -> [a]
-- tail []       = error "empty list"
-- tail (_ : xs) = xs

primes :: [Int]
primes = [ p | p <- [2..], isPrime p ]

upto :: Int -> [Int] -> [Int]
upto bound []                 = []
upto bound (x:xs) | x > bound = []
                  | otherwise = x : upto bound xs

l1 = upto 30 primes

-- Zip and search

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (zip)

-- zip :: [a] -> [b] -> [(a,b)]
-- zip [] ys         = []
-- zip xs []         = []
-- zip (x:xs) (y:ys) = (x,y) : zip xs ys

l2 = zip [0..] "word"

l3 = zip "word" (tail "word")

countDoubled :: String -> Int
countDoubled [] = 0
countDoubled xs = length [ x | (x,y) <- zip xs (tail xs), x==y ]

search :: String -> Char -> [Int]
search xs y = [ i | (i,x) <- zip [0..] xs, x==y ]

searchRec :: String -> Char -> [Int]
searchRec xs y = srch xs y 0
  where
    -- i is the index of the start of the substring
    srch :: String -> Char -> Int -> [Int]
    srch [] y i     = []
    srch (x:xs) y i
      | x == y    = i : srch xs y (i+1)
      | otherwise = srch xs y (i+1)

search' :: Eq a => [a] -> a -> [Int]
search' xs y = [ i | (i,x) <- zip [0..] xs, x==y ]

-- Select, take and drop

-- The following function definitions are commented out because they are already in the Prelude.
-- You can hide those definitions to allow them to be re-defined by putting the following at the top of this module:
-- import Prelude hiding ((!!), take, drop)

-- (!!) :: [a] -> Int -> a
-- (x:xs) !! 0 = x
-- [] !! i     = error "index too large"
-- (x:xs) !! i = xs !! (i-1)

-- take :: Int -> [a] -> [a]
-- take 0 xs     = []
-- take i []     = []
-- take i (x:xs) = x : take (i-1) xs

-- drop :: Int -> [a] -> [a]
-- drop 0 xs     = xs
-- drop i []     = []
-- drop i (x:xs) = drop (i-1) xs

-- Natural numbers

plus :: Int -> Int -> Int
plus m 0 = m
plus m n = (plus m (n-1)) + 1

times :: Int -> Int -> Int
times m 0 = 0
times m n = plus (times m (n-1)) m

power :: Int -> Int -> Int
power m 0 = 1
power m n = times (power m (n-1)) m

-- Recursion and induction

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding ((++))

-- (++) :: [a] -> [a] -> [a]
-- [] ++ ys     = ys
-- (x:xs) ++ ys = x : (xs ++ ys)

-- Exercise 7

plus' :: Int -> Int -> Int
plus' m 0 = m
plus' m n = plus' (m+1) (n-1)

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (reverse)

-- reverse :: [a] -> [a]
-- reverse []     = []
-- reverse (x:xs) = reverse xs ++ [x]
