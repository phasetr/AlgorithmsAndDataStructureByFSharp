-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

-- Representing sets as ordered lists without duplicates

module Chap20_data_representation_sets_as_lists_without_duplicates where

import Data.List(nub, sort)

type Set = [Int]

invariant :: Set -> Bool
invariant ns = and [ m < n | (m,n) <- zip ns (tail ns) ]

empty :: Set
empty = []

singleton :: Int -> Set
singleton n = [n]

set :: [Int] -> Set
set ns = nub (sort ns)

union :: Set -> Set -> Set
ms `union` []                     = ms
[] `union` ns                     = ns
(m:ms) `union` (n:ns) | m == n    = m : (ms `union` ns)
                      | m < n     = m : (ms `union` (n:ns))
                      | otherwise = n : ((m:ms) `union` ns)

s0 = set [1,42,2,7,1,3,2]

s1 = set [3,1,2] `union` set [1,7,4,1]

element :: Int -> Set -> Bool
m `element` []               = False
m `element` (n:ns) | m < n   = False
                   | m == n  = True
                   | m > n   = m `element` ns

equal :: Set -> Set -> Bool
ms `equal` ns = ms == ns

