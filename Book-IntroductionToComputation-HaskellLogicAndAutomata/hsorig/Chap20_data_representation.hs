-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

module Chap20_data_representation where

-- Rates of growth: big-O notation

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (elem)

-- elem :: Eq a => a -> [a] -> Bool
-- m `elem` []     = False
-- m `elem` (n:ns) = m==n || m `elem` ns

subset :: Eq a => [a] -> [a] -> Bool
ms `subset` ns = and [ m `elem` ns | m <- ms ]

-- Four ways of representing sets:
--
--   1. sets as lists
--   2. sets as ordered lists without duplicates
--   3. sets as ordered trees
--   4. sets as balanced trees
--
-- and
--
--   5. polymorphic sets as lists
--   6. polymorphic sets as balanced trees
--
-- are given in separate files in order to avoid name clashes

