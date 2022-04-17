-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as AVL trees as an abstract data type: previous problems solved

module AbstractSetAsAVLTree_MyModule where
  import AbstractSetAsAVLTree
  
  select :: Set -> Int
  select (Node _ n _ _) = n

  b0 = (set [0,3] `union` set [1,0,2]) `equal` (set [1,0,2] `union` set [0,3])

  i0 = select (set [0,3] `union` set [1,0,2])

  i0' = select (set [1,0,2] `union` set [0,3])

  b1 = 1 `element` (Node Nil 2 (Node Nil 1 Nil 1) 2)
