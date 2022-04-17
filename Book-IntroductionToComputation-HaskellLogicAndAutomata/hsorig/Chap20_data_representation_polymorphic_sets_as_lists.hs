-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

-- Representing polymorphic sets as lists

module Chap20_data_representation_polymorphic_sets_as_lists where

type Set a = [a]

empty :: Set a
empty = []

singleton :: a -> Set a
singleton n = [n]

set :: [a] -> Set a
set ns = ns

union :: Set a -> Set a -> Set a
ms `union` ns = ms ++ ns

element :: Eq a => a -> Set a -> Bool
n `element` ns = n `elem` ns

equal :: Eq a => Set a -> Set a -> Bool
ms `equal` ns = ms `subset` ns && ns `subset` ms
  where
  ms `subset` ns = and [ m `elem` ns | m <- ms ]


