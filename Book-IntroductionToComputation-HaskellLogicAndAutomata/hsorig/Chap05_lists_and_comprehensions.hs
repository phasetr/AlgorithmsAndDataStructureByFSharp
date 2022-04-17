-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 5 : Lists and Comprehensions

module Chap05_lists_and_comprehensions where

import Data.Char (toUpper, toLower)

-- Lists

someNumbers :: [Int]
someNumbers = [1,3,2,1,7]

someLists :: [[Int]]
someLists = [[1], [2,4,2], [], [3,5]]

someFunctions :: [Bool -> Bool -> Bool]
someFunctions = [(&&), (||)]

-- Functions on lists

headEven :: [Int] -> Bool
headEven xs | not (null xs) = even (head xs)
            | otherwise     = False

headEven' :: [Int] -> Bool
headEven' []     = False
headEven' (x:xs) = even x

sqrtSecond :: [Float] -> Float
sqrtSecond []      = -1.0
sqrtSecond (_:[])  = -1.0
sqrtSecond (_:a:_) = sqrt a

sqrtSecond' :: [Float] -> Float
sqrtSecond' []      = -1.0
sqrtSecond' [_]     = -1.0
sqrtSecond' (_:a:_) = sqrt a

-- Strings

capitalise :: String -> String
capitalise ""     = ""
capitalise (c:cs) = (toUpper c) : cs

-- Tuples

coordinates3D :: (Float,Float,Float)
coordinates3D = (1.2, -3.42, 2.7)

friends :: [(String,Int)]
friends = [("Hamish",21), ("Siobhan",19), ("Xiaoyu",21)]

metresToFtAndIn :: Float -> (Int,Int)
metresToFtAndIn metres = (feet,inches)
  where feet = floor (metres * 3.28084)
        inches = round (metres * 39.37008) - 12 * feet

nameAge :: (String,Int) -> String
nameAge (s,n) = s ++ "(" ++ show n ++ ")"

nameAge' :: (String,Int) -> String
nameAge' person = fst person ++ "(" ++ show (snd person) ++ ")"

-- List comprehensions

l1 = [ n*n | n <- [1,2,3] ]

l2 = [ toLower c | c <- "Hello, World!" ]

l3 = [ (n, even n) | n <- [1,2,3] ]

l4 = [ s++t | s <- ["fuzz","bizz"], t <- ["boom","whiz","bop"] ]

l5 = [ n*n | n <- [-3,-2,0,1,2,3,4,5], odd n, n>0 ]

l6 = [ s++t | s <- ["fuzz","bizz"], t <- ["boom","whiz","bop"], s<t ]

l7 = [ if n<0 then "neg" else "pos" | n <- [3,2,-1,5,-2], odd n ]

squares :: [Int] -> [Int]
squares ns = [ n*n | n <- ns ]

odds :: [Int] -> [Int]
odds ns = [ n | n <- ns, odd n ]

sumSqOdds :: [Int] -> Int
sumSqOdds ns = sum [ n*n | n <- ns, odd n ]

-- Enumeration expressions

l8 = [10,9..0]

l9 = [10,8..0]

l10 = ['a'..'p']

isPrime :: Int -> Bool
isPrime n = null [ n | x <- [2..n-1], n `mod` x == 0 ]

pythagoreanTriples :: [(Int,Int,Int)]
pythagoreanTriples =
  [ (a,b,c) | a <- [1..10], b <- [1..10], c <- [1..10],
              a^2 + b^2 == c^2 ]

i = head (tail [0..])

-- Lists and sets

intersect :: Eq a => [a] -> [a] -> [a]
s `intersect` t = [ x | x <- s, x `elem` t ]
