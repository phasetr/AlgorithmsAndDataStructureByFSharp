module S2_6_5 where

-- | P.38
-- Node 5 [Node 8 [Node 3 [], Node 1 []], Node 6 [Node 4 []]]
data Tree a = Node a [Tree a] deriving Show
-- | P.38
-- NodeBT 5 (NodeBT 8 (NodeBT 3 Empty Empty) (NodeBT 1 Empty Empty)) (NodeBT 6 Empty (NodeBT 4 Empty Empty))
-- NodeBT 5 (NodeBT 8 (NodeBT 3 Empty Empty) (NodeBT 1 Empty Empty)) (NodeBT 6 (NodeBT 2 Empty Empty) (NodeBT 4 Empty Empty))
data BinTree a  = Empty | NodeBT a (BinTree a) (BinTree a) deriving Show
-- | P.38
-- NodeBT' 5 (NodeBT' 8 (Leaf 3) (Leaf 1)) (NodeBT' 6 (Leaf 2) (Leaf 4))
data BinTree' a = Leaf a | NodeBT' a (BinTree' a) (BinTree' a) deriving Show

-- | P.39
depth :: Tree a -> Int
depth (Node _ [])    = 1
depth (Node _ succs) = 1 + maximum (map depth succs)
-- | P.39
depth' :: BinTree a -> Int
depth' Empty            = 0
depth' (NodeBT _ lf rt) = 1 + max (depth' lf) (depth' rt)
-- | Only in the distributed source
count :: BinTree a -> Int
count Empty            = 1
count (NodeBT _ lf rt) = count lf + count rt
-- | P.39
countEmpty :: BinTree a -> Int
countEmpty Empty            = 1
countEmpty (NodeBT _ lf rt) = countEmpty lf + countEmpty rt

-- | P.39
tsum :: (Num a) => BinTree  a -> a
tsum Empty            = 0
tsum (NodeBT a lf rt) = a + tsum lf + tsum rt
-- | P.39
tsum' :: (Num a) => BinTree'  a -> a
tsum' (Leaf v)          = v
tsum' (NodeBT' v lf rt) = v + tsum' lf + tsum' rt

-- | P.40
preorder :: BinTree a -> [a]
preorder Empty            = []
preorder (NodeBT a lf rt) = [a] ++ preorder lf ++ preorder rt
-- | P.40
inorder :: BinTree a -> [a]
inorder Empty            = []
inorder (NodeBT a lf rt) = inorder lf ++ [a] ++ inorder rt
-- | P.40
postorder :: BinTree a -> [a]
postorder Empty            = []
postorder (NodeBT a lf rt) = postorder lf ++ postorder rt ++ [a]

test :: Bool
test = depth' bt == 3
  && count bt == 7
  && tsum bt == 27
  && tsum' bt' == 29
  && preorder bt == [5, 8, 3, 1, 6, 4]
  && inorder bt == [3, 8, 1, 5, 6, 4]
  && postorder bt  == [3, 1, 8, 4, 6, 5]
  where
    bt = NodeBT 5 (NodeBT 8 (NodeBT 3 Empty Empty) (NodeBT 1 Empty Empty)) (NodeBT 6 Empty (NodeBT 4 Empty Empty))
    bt' = NodeBT' 5 (NodeBT' 8 (Leaf 3) (Leaf 1)) (NodeBT' 6 (Leaf 2) (Leaf 4))
