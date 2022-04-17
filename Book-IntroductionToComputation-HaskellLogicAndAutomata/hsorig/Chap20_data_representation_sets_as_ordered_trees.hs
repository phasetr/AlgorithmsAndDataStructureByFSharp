-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

-- Representing sets as ordered trees

module Chap20_data_representation_sets_as_ordered_trees where

data Set = Nil | Node Set Int Set
  deriving Show

s0 =
  Node (Node (Node (Node Nil 1 Nil) 2 Nil)
             6
             (Node Nil 10 (Node Nil 12 Nil)))
       17
       (Node (Node (Node Nil 18 Nil)
                   20
                   (Node Nil 29 (Node Nil 34 Nil)))
             35
             (Node (Node Nil 37 Nil)
                   42
                   (Node (Node Nil 48 Nil) 50 Nil)))

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

singleton :: Int -> Set
singleton n = Node Nil n Nil

insert :: Int -> Set -> Set
insert m Nil = Node Nil m Nil
insert m (Node l n r)
  | m == n   = Node l n r
  | m < n    = Node (insert m l) n r
  | m > n    = Node l n (insert m r)

s1 = insert 11 s0

set :: [Int] -> Set
set = foldr insert empty

union :: Set -> Set -> Set
ms `union` ns = foldr insert ms (list ns)

element :: Int -> Set -> Bool
m `element` Nil = False
m `element` (Node l n r)
  | m == n      = True
  | m < n       = m `element` l
  | m > n       = m `element` r

b1 = 15 `element` s1

equal :: Set -> Set -> Bool
s `equal` t = list s == list t

