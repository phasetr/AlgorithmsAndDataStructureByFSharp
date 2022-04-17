-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 3 : Simple Computations

module Chap03_simple_computations where

-- Function definitions

square :: Int -> Int
square n = n * n

pyth :: Int -> Int -> Int
pyth x y = square x + square y

(**) :: Int -> Int -> Int
m ** n = m ^ n + n ^ m

even :: Int -> Bool
even n = n `mod` 2 == 0

-- Case analysis

abs :: Int -> Int
abs n = if n<0 then -n else n

max3 :: Int -> Int -> Int -> Int
max3 a b c
  | a>=b && a>=c = a
  | b>=a && b>=c = b
  | otherwise    = c       -- here, c>=a and c>=b

-- Defining functions by cases

-- The following type and function definitions are commented out because they are already in the Prelude.
-- You can hide those definitions to allow them to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Bool, True, False, not, (&&))

-- data Bool = False | True

-- not :: Bool -> Bool
-- not False = True
-- not True  = False

-- (&&) :: Bool -> Bool -> Bool
-- True && y  = y
-- False && y = False

-- alternative definition:
-- (&&) :: Bool -> Bool -> Bool
-- True && True  = True
-- _ && _        = False

-- Dependencies and scope

angleVectors :: Float -> Float -> Float -> Float -> Float
angleVectors a b a' b' = acos phi
  where phi = (dotProduct a b a' b')
                / (lengthVector a b * lengthVector a' b')

dotProduct :: Float -> Float -> Float -> Float -> Float
dotProduct x y x' y' = (x * x') + (y * y')

lengthVector :: Float -> Float -> Float
lengthVector x y = sqrt (dotProduct x y x y)

angleVectors' :: Float -> Float -> Float -> Float -> Float
angleVectors' a b a' b' = acos phi
  where phi = (dotProduct a b a' b')
                / (lengthVector a b * lengthVector a' b')

        dotProduct ::
          Float -> Float -> Float -> Float -> Float
        dotProduct x y x' y' = (x * x') + (y * y')

        lengthVector :: Float -> Float -> Float
        lengthVector x y = sqrt (dotProduct x y x y)
