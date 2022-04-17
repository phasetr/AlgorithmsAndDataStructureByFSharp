-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

-- Representing sets as lists

module Chap20_data_representation_sets_as_lists where

type Set = [Int]

empty :: Set
empty = []

singleton :: Int -> Set
singleton n = [n]

set :: [Int] -> Set
set ns = ns

union :: Set -> Set -> Set
ms `union` ns = ms ++ ns

element :: Int -> Set -> Bool
n `element` ns = n `elem` ns

equal :: Set -> Set -> Bool
ms `equal` ns = ms `subset` ns && ns `subset` ms
  where
  ms `subset` ns = and [ m `elem` ns | m <- ms ]


