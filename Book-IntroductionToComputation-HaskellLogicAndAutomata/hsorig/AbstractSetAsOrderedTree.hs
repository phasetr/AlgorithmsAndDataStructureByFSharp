-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as ordered trees as an abstract data type, with expanded API

module AbstractSetAsOrderedTree
  ( Set, empty, isEmpty, singleton, select, set, union, delete, element, equal ) where

  data Set = Nil | Node Set Int Set

  invariant :: Set -> Bool
  invariant Nil          = True
  invariant (Node l n r) =
    and [ m < n | m <- list l ] &&
    and [ m > n | m <- list r ] &&
    invariant l && invariant r

  list :: Set -> [Int]
  list Nil          = []
  list (Node l n r) = list l ++ [n] ++ list r

  empty :: Set
  empty = Nil

  isEmpty :: Set -> Bool
  isEmpty Nil          = True
  isEmpty (Node _ _ _) = False

  singleton :: Int -> Set
  singleton n = Node Nil n Nil

  select :: Set -> Int
  select s = head (list s)

  insert :: Int -> Set -> Set
  insert m Nil = Node Nil m Nil
  insert m (Node l n r)
    | m == n   = Node l n r
    | m < n    = Node (insert m l) n r
    | m > n    = Node l n (insert m r)

  set :: [Int] -> Set
  set = foldr insert empty

  union :: Set -> Set -> Set
  ms `union` ns = foldr insert ms (list ns)

  delete :: Int -> Set -> Set
  delete m Nil           = Nil
  delete m (Node l n r)
    | m < n               = Node (delete m l) n r
    | m > n               = Node l n (delete m r)
    | m == n && isEmpty l = r
    | m == n && isEmpty r = l
    | otherwise           = Node l min (delete min r)
                              where min = select r

  element :: Int -> Set -> Bool
  m `element` Nil = False
  m `element` (Node l n r)
    | m == n      = True
    | m < n       = m `element` l
    | m > n       = m `element` r

  equal :: Set -> Set -> Bool
  s `equal` t = list s == list t
