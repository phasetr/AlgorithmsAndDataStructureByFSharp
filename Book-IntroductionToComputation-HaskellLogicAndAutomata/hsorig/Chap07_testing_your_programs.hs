-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 7 : Testing Your Programs

module Chap07_testing_your_programs where

import Chap05_lists_and_comprehensions (squares, odds, sumSqOdds)

import Test.QuickCheck (quickCheck, withMaxSuccess, Property, (==>), Arbitrary, arbitrary, elements)

-- Making mistakes

-- commented out to avoid these errors blocking experiments with what follows

-- sumSqOdds :: [Int] -> Int
-- sumSqOdds ns = sum [ n*n | ns -> n, odd n ] -- Should be ``n <- ns'', not ``ns -> n''

-- sumSqOdds :: [Int] -> Int
-- sumSqOdds ns = sum [ n*n | n <- ns, n odd ] -- Should be ``odd n'', not ``n odd''

-- sumSqOdds :: [Int] -> Int
-- sumSqOdds ns = sum [ n*n | n <- ns, odf n ] -- Typo in ``odd n''

allDifferent :: Int -> Int -> Int -> Bool
allDifferent a b c | a/=b && b/=c = True
                   | otherwise    = False

-- Finding mistakes using testing

t1 = allDifferent 1 2 3

t2 = allDifferent 0 0 0

t3 = allDifferent 1 1 0

t4 = allDifferent 0 1 1

t5 = allDifferent 1 0 1

-- Property-based testing

sumSqOdds' :: [Int] -> Int
sumSqOdds' ns = sum (squares (odds ns))

sumSqOdds_prop1 :: [Int] -> Bool
sumSqOdds_prop1 ns = sumSqOdds ns <= sum (squares ns)

sumSqOdds_prop2 :: [Int] -> Bool
sumSqOdds_prop2 ns = odd (length (odds ns)) == odd (sumSqOdds ns)

sumSqOdds_prop3 :: [Int] -> Bool
sumSqOdds_prop3 ns = sumSqOdds ns == sumSqOdds' ns

sumSqOdds_prop1' :: [Int] -> Bool
sumSqOdds_prop1' ns = sumSqOdds ns < sum (squares ns)

-- Automated testing using QuickCheck

qc1 = quickCheck sumSqOdds_prop1

qc2 = quickCheck sumSqOdds_prop2

qc3 = quickCheck sumSqOdds_prop3

qc4 = quickCheck sumSqOdds_prop1'

qc5 = quickCheck (withMaxSuccess 1000000 sumSqOdds_prop3)

allDifferent_prop :: Int -> Int -> Int -> Bool
allDifferent_prop a b c
  | allDifferent a b c
              = a/=b && a/=c && b/=a && b/=c && c/=a && c/=b
  | otherwise = a==b || a==c || b==a || b==c || c==a || c==b

qc6 = quickCheck allDifferent_prop

-- Conditional tests

newton :: Float -> Float -> Float
newton n r = (r + (n / r)) / 2.0

newton_prop :: Float -> Float -> Property
newton_prop n r =
  n>=0 && r>0 ==> distance n (newton n r) <= distance n r
    where distance n root = abs (root^2 - n)

qc7 = quickCheck newton_prop

-- Test case generation

data Weekday = Monday | Tuesday | Wednesday | Thursday
                      | Friday | Saturday | Sunday
  deriving Show

isSaturday :: Weekday -> Bool
isSaturday Saturday = True
isSaturday _        = False

isSaturday_prop :: Weekday -> Bool
isSaturday_prop d = not (isSaturday d)

instance Arbitrary Weekday where
    arbitrary = elements [Monday, Tuesday, Wednesday,
                          Thursday, Friday, Saturday, Sunday]

qc8 = quickCheck isSaturday_prop 

-- Testing polymorphic properties

append_prop :: Eq a => [a] -> [a] -> Bool
append_prop xs ys = xs ++ ys == ys ++ xs

-- qc9 = quickCheck append_prop

append_prop' :: [Int] -> [Int] -> Bool
append_prop' xs ys = xs ++ ys == ys ++ xs

qc9' = quickCheck append_prop'

