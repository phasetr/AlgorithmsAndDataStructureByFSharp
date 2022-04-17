-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 13 : Higher and Higher

module Chap13_higher_and_higher where

import Chap05_lists_and_comprehensions (isPrime)

import Chap12_higher_order_functions (sumSqOdds')

-- Lambda expressions

f :: [Int] -> Int
f ns = foldr (+) 0 (map sqr (filter pos ns))
         where sqr x = x * x
               pos x = x >= 0

f' :: [Int] -> Int
f' ns = foldr (+) 0 (map (^ 2) (filter (>= 0) ns))

f'' :: [Int] -> Int
f'' ns = foldr (+) 0
           (map (\x -> x * x)
             (filter (\x -> x >= 0) ns))

-- Function composition

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding ((.))

-- (.) :: (b -> c) -> (a -> b) -> a -> c
-- (f . g) x = f (g x)

sumSqOdds'' :: [Int] -> Int
sumSqOdds'' = foldr (+) 0 . map (^ 2) . filter odd

squareNonprimes :: [Int] -> [Int]
squareNonprimes = map (^ 2) . filter (not . isPrime)

-- The function application operator $

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (($))

-- ($) :: (a -> b) -> a -> b
-- f $ x = f x

sumSqOdds''' :: [Int] -> Int
sumSqOdds''' ns = foldr (+) 0 $ map (^ 2) $ filter odd ns

-- Currying and uncurrying functions

l1 = filter (\(x,y) -> x < y)
            (zip ["one", "two", "three", "four", "five"]
                 ["eins", "zwei", "drei", "vier", "fünf"])

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (curry)

-- curry :: ((a,b) -> c) -> a -> b -> c
-- curry f x y = f (x,y)

curry' :: ((a,b) -> c) -> a -> b -> c
curry' f = \x -> \y -> f (x,y)

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (uncurry)

-- uncurry :: (a -> b -> c) -> (a,b) -> c
-- uncurry f (x,y) = f x y

uncurry' :: (a -> b -> c) -> (a,b) -> c
uncurry' f = \(x,y) -> f x y

l2 = filter (uncurry (<))
            (zip ["one", "two", "three", "four", "five"]
                 ["eins", "zwei", "drei", "vier", "fünf"])

-- Bindings and lambda expressions

i1 = f 2
       where f x = x + y * y
                     where y = x + 1

i2 = (\f -> f 2) (\x -> ((\y -> x + y * y) (x + 1)))


f''' x = w ^ 2
           where w = x + 2
g y = f''' (y * z)
        where z = y + 1
i3 = g b
       where b = f''' 3

i4 = g b
       where b = f''' 3
                   where f''' x = w ^ 2
                                    where w = x + 2
             g y = f''' (y * z)
                     where z = y + 1
                           f''' x = w ^ 2
                                      where w = x + 2

i5 = (\b -> \g -> g b)
       ((\f''' -> f''' 3) (\x -> (\w -> w ^ 2) (x + 2)))
       (\y -> (\z -> \f''' -> f''' (y * z))
                (y + 1)
                (\x -> (\w -> w ^ 2) (x + 2)))

-- Exercise 6

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (unzip)

-- unzip :: [(a,b)] -> ([a],[b])
-- unzip [] = ([],[])
-- unzip ((x,y):xys) = (x:xs,y:ys)
--                       where (xs,ys) = unzip xys

-- Exercise 8

-- iter is from Exercise 1

iter :: Int -> (a -> a) -> (a -> a)
iter = undefined

type Church a = (a -> a) -> a -> a

church :: Int -> Church a
church n = iter n

succ :: Church a -> Church a
succ cm = \f -> \x -> f (cm f x)

plus :: Church a -> Church a -> Church a
plus cm cn = \f -> \x -> cm f (cn f x)

unchurch :: Church Int -> Int
unchurch cn = cn (+ 1) 0
