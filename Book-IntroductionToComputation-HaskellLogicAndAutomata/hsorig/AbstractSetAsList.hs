-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as lists as an abstract data type, with expanded API

module AbstractSetAsList
  ( Set, empty, isEmpty, singleton, select, set, union, delete, element, equal ) where

  data Set = MkSet [Int]

  empty :: Set
  empty = MkSet []
  
  isEmpty :: Set -> Bool
  isEmpty (MkSet ns) = null ns

  singleton :: Int -> Set
  singleton n = MkSet [n]

  select :: Set -> Int
  select (MkSet ns) = minimum ns        -- ensures that select s == select t whenever s `equal` t

  set :: [Int] -> Set
  set ns = MkSet ns

  union :: Set -> Set -> Set
  MkSet ms `union` MkSet ns = MkSet (ms ++ ns)

  delete :: Int -> Set -> Set
  delete m (MkSet []) = MkSet []
  delete m (MkSet (n:ns))
    | m == n    = delete m (MkSet ns)   -- delete all occurrences
    | otherwise = insert n (delete m (MkSet ns))

  insert :: Int -> Set -> Set           -- required only for delete
  insert n (MkSet ns) = MkSet (n:ns)

  element :: Int -> Set -> Bool
  n `element` MkSet ns = n `elem` ns

  equal :: Set -> Set -> Bool
  MkSet ms `equal` MkSet ns = ms `subset` ns && ns `subset` ms
    where
    ms `subset` ns = and [ m `elem` ns | m <- ms ]


