-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 14 : Sequent Calculus

-- Required for "instance Show (u -> Bool) ..." in Exercise 1

{-# LANGUAGE FlexibleInstances #-}

module Chap14_sequent_calculus where

-- used in Exercise 1

import Test.QuickCheck (Arbitrary, arbitrary, elements, CoArbitrary, coarbitrary, variant)

-- Combining predicates

-- Predicate is from "Features and Predicates"

type Predicate u = u -> Bool

neg :: Predicate u -> Predicate u
(neg a) x = not (a x)

(&:&) :: Predicate u -> Predicate u -> Predicate u
(a &:& b) x = a x && b x

(|:|) :: Predicate u -> Predicate u -> Predicate u
(a |:| b) x = a x || b x

-- Exercise 1

-- Thing is from "Features and Predicates"

data Thing = R | S | T | U | V | W | X | Y | Z deriving (Eq,Show)

instance Arbitrary Thing where
  arbitrary = elements [R, S, T, U, V, W, X, Y, Z]

instance CoArbitrary Thing where
  coarbitrary R = variant 0
  coarbitrary S = variant 1
  coarbitrary T = variant 2
  coarbitrary U = variant 3
  coarbitrary V = variant 4
  coarbitrary W = variant 5
  coarbitrary X = variant 6
  coarbitrary Y = variant 7
  coarbitrary Z = variant 8

instance Show (u -> Bool) where
  show p = "a predicate"
