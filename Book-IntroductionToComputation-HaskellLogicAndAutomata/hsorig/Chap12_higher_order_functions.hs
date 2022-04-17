-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 12 : Higher-Order Functions

module Chap12_higher_order_functions where

import Chap05_lists_and_comprehensions (squares, odds, isPrime, sumSqOdds)

import Chap10_lists_and_recursion (oddsRec) -- also sum, product, and, which are in the Prelude

import Chap11_more_fun_with_recursion (prodFromTo) -- also enumFromTo, which is in the Prelude

import Data.Char (ord, isDigit)

-- Patterns of computation

enumFromTo' = enumPattern (:) []
prodFromTo' = enumPattern (*) 1

enumPattern :: (Int -> t -> t) -> t -> Int -> Int -> t
enumPattern f e m n | m > n  = e
                    | m <= n = f m  (enumPattern f e (m+1) n)

-- Map

ords :: [Char] -> [Int]
ords xs = [ ord x | x <- xs ]

l1 = ords "cat"

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (map)

-- map :: (a -> b) -> [a] -> [b]
-- map f xs = [ f x | x <- xs ]

squares' :: [Int] -> [Int]
squares' = map sqr
             where sqr x = x*x

ords' :: [Char] -> [Int]
ords' = map ord

squaresRec :: [Int] -> [Int]
squaresRec []     = []
squaresRec (x:xs) = x*x : squaresRec xs

ordsRec :: [Char] -> [Int]
ordsRec []     = []
ordsRec (x:xs) = ord x : ordsRec xs

mapRec :: (a -> b) -> [a] -> [b]
mapRec f []     = []
mapRec f (x:xs) = f x : mapRec f xs

squaresRec' :: [Int] -> [Int]
squaresRec' = mapRec sqr
                where sqr x = x*x

-- Filter

digits :: [Char] -> [Char]
digits xs = [ x | x <- xs, isDigit x ]

digitsRec :: [Char] -> [Char]
digitsRec []                 = []
digitsRec (x:xs) | isDigit x = x : digitsRec xs
                 | otherwise = digitsRec xs

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (filter)

-- filter :: (a -> Bool) -> [a] -> [a]
-- filter p xs = [ x | x <- xs, p x ]

filterRec :: (a -> Bool) -> [a] -> [a]
filterRec p []                 = []
filterRec p (x:xs) | p x       = x : filterRec p xs
                   | otherwise = filterRec p xs

odds' :: [Int] -> [Int]
odds' = filter odd

digits' :: [Char] -> [Char]
digits' = filter isDigit

-- Fold

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (concat)

-- concat :: [[a]] -> [a]
-- concat []       = []
-- concat (xs:xss) = xs ++ concat xss

l2 = concat [[1,2,3],[4,5]]

l3 = concat ["con","cat","en","ate"]

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (foldr)

-- foldr :: (a -> a -> a) -> a -> [a] -> a
-- foldr f v []     = v
-- foldr f v (x:xs) = f x (foldr f v xs)

foldr' :: (a -> a -> a) -> a -> [a] -> a
foldr' f v []     = v
foldr' f v (x:xs) = x `f` (foldr' f v xs)

sum' :: [Int] -> Int
sum' = foldr (+) 0

product' :: [Int] -> Int
product' = foldr (*) 1

and' :: [Bool] -> Bool
and' = foldr (&&) True

concat' :: [[a]] -> [a]
concat' = foldr (++) []

-- foldr and foldl

sum'' :: [Int] -> Int
sum'' = foldl (+) 0

product'' :: [Int] -> Int
product'' = foldl (*) 1

and'' :: [Bool] -> Bool
and'' = foldl (&&) True

concat'' :: [[a]] -> [a]
concat'' = foldl (++) []

cumulativeDivide :: Int -> [Int] ->Int
cumulativeDivide i = foldl div i

(<:) :: [a] -> a -> [a]
xs <: x = x : xs

reverse' :: [a] -> [a]
reverse' = foldl (<:) []

-- The following function definitions are commented out because they are already in the Prelude.
-- You can hide those definitions to allow them to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (foldr1, maximum)

-- foldr1 :: (a -> a -> a) -> [a] -> a
-- foldr1 f []     = error "empty list"
-- foldr1 f [x]    = x
-- foldr1 f (x:xs) = x `f` (foldr1 f xs)

-- maximum :: [Int] -> Int
-- maximum = foldr1 max

-- Combining map, filter and foldr/foldl

dblPrimes :: [Int] -> [Int]
dblPrimes ns = [ 2*n | n <- ns, isPrime n ]

dblPrimes' :: [Int] -> [Int]
dblPrimes' ns = map dbl (filter isPrime ns)
                  where dbl x = 2*x

sumSqOdds' :: [Int] -> Int
sumSqOdds' ns = foldr (+) 0 (map sqr (filter odd ns))
                  where sqr x = x*x

-- Curried types and partial application

increment :: Int -> Int
increment = (+) 1

isPositive :: Int -> Bool
isPositive = (<=) 0

pow2 :: Int -> Int
pow2 = (^) 2

pow2' = (2 ^)
isVowel = (`elem` "aeiouAEIOU")
squares'' = map (^ 2)
