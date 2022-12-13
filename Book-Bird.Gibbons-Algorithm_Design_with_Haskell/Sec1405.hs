module Sec1405 where
import Lib (Nat)
-- P.347 14.5 Optimum binary search trees

-- P.348
data BST a = Leaf Nat | Node Nat (BST a) a (BST a)

-- P.348
cost :: BST a -> Nat
cost t = sum (zipWith (*) (flatten t) (depths t))

flatten :: BST a -> [Nat]
flatten (Leaf q) = [q]
flatten (Node p l x r) = flatten l ++ [p] ++ flatten r
depths :: BST a -> [Nat]
depths = from 0 where
  from d (Leaf _) = [d]
  from d (Node _ l _ r) = from (d+1) l ++ [d+1] ++ from (d+1) r

--p P.348
costHuffman :: BST a -> Nat
costHuffman (Leaf q) = 0
costHuffman (Node p l x r) = cost l + cost r + weight (Node p l x r)
weight :: BST a -> Nat
weight (Leaf q) = q
weight (Node p l x r) = p + weight l + weight r
