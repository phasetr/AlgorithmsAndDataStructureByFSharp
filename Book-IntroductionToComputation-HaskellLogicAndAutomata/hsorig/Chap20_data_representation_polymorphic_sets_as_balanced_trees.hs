-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 20 : Data Representation

-- Representing polymorphic sets as balanced trees

module Chap20_data_representation_polymorphic_sets_as_balanced_trees where

type Depth = Int
data Set a = Nil | Node (Set a) a (Set a) Depth
  deriving Show

depth :: Set a -> Int
depth Nil = 0
depth (Node _ _ _ d) = d

node :: Set a -> a -> Set a -> Set a
node l n r = Node l n r (1 + (depth l `max` depth r))

invariant :: Ord a => Set a -> Bool
invariant Nil            = True
invariant (Node l n r d) =
  and [ m < n | m <- list l ] &&
  and [ m > n | m <- list r ] &&
  abs (depth l - depth r) <= 1 &&
  d == 1 + (depth l `max` depth r) &&
  invariant l && invariant r

insert :: Ord a => a -> Set a -> Set a
insert m Nil = node empty m empty
insert m (Node l n r _)
  | m == n   = node l n r
  | m < n    = rebalance (node (insert m l) n r)
  | m > n    = rebalance (node l n (insert m r))

rebalance :: Ord a => Set a -> Set a
rebalance (Node (Node a m b _) n c _)
  | depth a >= depth b && depth a > depth c
            = node a m (node b n c)
rebalance (Node a m (Node b n c _) _)
  | depth c >= depth b && depth c > depth a
            = node (node a m b) n c
rebalance (Node (Node a m (Node b n c _) _) p d _)
  | depth (node b n c) > depth d
            = node (node a m b) n (node c p d)
rebalance (Node a m (Node (Node b n c _) p d _) _)
  | depth (node b n c) > depth a
            = node (node a m b) n (node c p d)
rebalance a = a

s0 =
  Node (Node (Node (Node Nil 1 Nil 1) 2 Nil 2)
             6
             (Node Nil 10 (Node Nil 12 Nil 1) 2)
             3)
       17
       (Node (Node (Node Nil 18 Nil 1)
                   20
                   (Node Nil 29 (Node Nil 34 Nil 1) 2)
                   3)
             35
             (Node (Node Nil 37 Nil 1)
                   42
                   (Node (Node Nil 48 Nil 1) 50 Nil 2)
                   3)
             4)
       5

s1 = insert 11 s0

empty :: Set a
empty = Nil

singleton :: a -> Set a
singleton n = Node Nil n Nil 1

list :: Set a -> [a]
list Nil            = []
list (Node l n r _) = list l ++ [n] ++ list r

set :: Ord a => [a] -> Set a
set = foldr insert empty

union :: Ord a => Set a -> Set a -> Set a
ms `union` ns = foldr insert ms (list ns)

element :: Ord a => a -> Set a -> Bool
m `element` Nil = False
m `element` (Node l n r _)
  | m == n      = True
  | m < n       = m `element` l
  | m > n       = m `element` r

equal :: Eq a => Set a -> Set a -> Bool
s `equal` t = list s == list t
