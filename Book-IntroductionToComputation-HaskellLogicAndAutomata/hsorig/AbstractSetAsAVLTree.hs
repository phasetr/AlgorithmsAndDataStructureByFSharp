-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as AVL trees as an abstract data type

module AbstractSetAsAVLTree
  ( Set, empty, singleton, set, union, element, equal ) where

  type Depth = Int
  data Set = Nil | Node Set Int Set Depth
    deriving Show

  depth :: Set -> Int
  depth Nil = 0
  depth (Node _ _ _ d) = d

  node :: Set -> Int -> Set -> Set
  node l n r = Node l n r (1 + (depth l `max` depth r))

  invariant :: Set -> Bool
  invariant Nil            = True
  invariant (Node l n r d) =
    and [ m < n | m <- list l ] &&
    and [ m > n | m <- list r ] &&
    abs (depth l - depth r) <= 1 &&
    d == 1 + (depth l `max` depth r) &&
    invariant l && invariant r

  insert :: Int -> Set -> Set
  insert m Nil = node empty m empty
  insert m (Node l n r _)
    | m == n   = node l n r
    | m < n    = rebalance (node (insert m l) n r)
    | m > n    = rebalance (node l n (insert m r))

  rebalance :: Set -> Set
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

  empty :: Set
  empty = Nil

  singleton :: Int -> Set
  singleton n = Node Nil n Nil 1

  list :: Set -> [Int]
  list Nil            = []
  list (Node l n r _) = list l ++ [n] ++ list r

  set :: [Int] -> Set
  set = foldr insert empty

  union :: Set -> Set -> Set
  ms `union` ns = foldr insert ms (list ns)

  element :: Int -> Set -> Bool
  m `element` Nil = False
  m `element` (Node l n r _)
    | m == n      = True
    | m < n       = m `element` l
    | m > n       = m `element` r
  element _ _ = error "not come here"

  equal :: Set -> Set -> Bool
  s `equal` t = list s == list t
