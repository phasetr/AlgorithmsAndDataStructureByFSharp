-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as lists

module SetAsList
  ( Set, empty, singleton, set, union, element, equal ) where

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


