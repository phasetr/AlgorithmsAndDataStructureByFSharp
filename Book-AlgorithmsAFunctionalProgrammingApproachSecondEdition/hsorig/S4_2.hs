module S4_2 where

-- | P.77, see Section 2.6.5
data BinTree a = Empty | NodeBT a (BinTree a) (BinTree a) deriving (Show,Eq)

-- P.77, 4.2.2 composing tree operations
-- | P.78, 以下の関数の合成.
tcomp :: BinTree Int -> Int
tcomp = tsum . tdouble
-- | P.78, 各ノードを二倍にする.
tdouble :: BinTree Int -> BinTree Int
tdouble Empty = Empty
tdouble (NodeBT v lf rt) = NodeBT (2*v) (tdouble lf) (tdouble rt)
-- | P.78, 全ノードの和を取る.
tsum :: BinTree Int -> Int
tsum Empty = 0
tsum (NodeBT v lf rt) = v + tsum lf + tsum rt

-- | P.79, 全ノードの和を取る.
tcomp' :: BinTree Int -> Int
tcomp' Empty = 0
tcomp' (NodeBT v lf rt) = (2*v) + tcomp' lf + tcomp' rt

-- P.79 4.2.3 Reducing the number of passes
-- P.79
countDepth :: BinTree a -> (Int, Int)
countDepth t = (count t, depth t)

-- | P.79, counting and finding depth in one pass
countDepth' :: (Num a1, Num b, Ord b) => BinTree a2 -> (a1, b)
countDepth' Empty = (1,0)
countDepth' (NodeBT v lf rt) = (c1 + c2, 1 + max d1 d2) where
  (c1,d1) = countDepth' lf
  (c2,d2) = countDepth' rt

-- | P.79
comp :: Fractional a => BinTree Int -> BinTree a
comp t = perc (tsum t) t
-- | P.79, 比の計算, percentage
perc :: (Fractional a1, Integral a2, Integral t) => t -> BinTree a2 -> BinTree a1
perc x Empty = Empty
perc x (NodeBT v lf rt) =
  NodeBT (fromIntegral v / fromIntegral x) (perc x lf) (perc x rt)
-- | P.79, in one pass
comp'' :: (Fractional a1, Integral a2) => BinTree a2 -> BinTree a1
comp'' t = t' where (t', x) = comp' x t
-- | P.80
comp' :: (Fractional a1, Integral b, Integral a2) => a2 -> BinTree b -> (BinTree a1, b)
comp' x Empty = (Empty, 0)
comp' x (NodeBT v lf rt) = (NodeBT (fromIntegral v / fromIntegral x) p1 p2, v + s1 + s2)
  where
    (p1,s1) = comp' x lf
    (p2,s2) = comp' x rt

-- | P.39, counting and finding depth
depth :: BinTree a -> Int
depth Empty            = 0
depth (NodeBT _ lf rt) = 1 + max (depth lf) (depth rt)
-- | Only in the distributed source, counting and finding depth
count :: BinTree a -> Int
count Empty            = 1
count (NodeBT _ lf rt) = count lf + count rt

-- P.80, 4.2.4 Removing appends revisited
-- | P.80
inorder :: BinTree a -> [a]
inorder Empty = []
inorder (NodeBT a lf rt) = inorder lf ++ [a] ++ inorder rt
-- | P.80
inorder' :: BinTree a -> [a]
inorder' t = inorder'' t [] where
  inorder'' Empty z = z
  inorder'' (NodeBT a lf rt) z = inorder'' lf (a : inorder'' rt z)

-- P.81, 4.2.5 Copying in trees
data BinTree'' a = Leaf'' a | Node'' (BinTree'' a) (BinTree'' a) deriving (Show,Eq)
-- | Sample data
bt' :: BinTree'' Int
bt' = Node'' (Node'' (Leaf'' 1) (Leaf'' 2))
             (Node'' (Leaf'' 3) (Leaf'' 4))
-- | P.81
flipT :: BinTree'' a -> BinTree'' a
flipT (Node'' a b) = Node'' (flipT b) (flipT a)
-- flipT (Leaf'' a) = Leaf'' a
flipT x@(Leaf'' a) = x

-- P.81, 4.2.6 Storing additional information in the tree
-- | P.81
tinsert :: a -> BinTree a -> BinTree a
tinsert v Empty = NodeBT v Empty Empty
tinsert v (NodeBT w lf rt)
  | count lf <= count rt = NodeBT w (tinsert v lf) rt
  | otherwise            = NodeBT w lf (tinsert v rt)

-- | P.81
data BinTreeSz a = EmptySz | NodeBTSz (Int,Int) a (BinTreeSz a) (BinTreeSz a) deriving (Show,Eq)
-- | Sample data
btSz :: BinTreeSz Integer
btSz = NodeBTSz (3,2) 5 (NodeBTSz (1,1) 8 (NodeBTSz (0,0) 3 EmptySz EmptySz)
                                          (NodeBTSz (0,0) 1 EmptySz EmptySz))
                        (NodeBTSz (0,1) 6 EmptySz
                                          (NodeBTSz (0,0) 4 EmptySz EmptySz))

-- | P.81
tinsertSz :: a -> BinTreeSz a -> BinTreeSz a
tinsertSz v EmptySz = NodeBTSz (0,0) v EmptySz EmptySz
tinsertSz v (NodeBTSz (s1,s2) w lf rt)
  | s1 <= s2 = NodeBTSz (s1+1, s2) w (tinsertSz v lf) rt
  | otherwise = NodeBTSz (s1,s2+1) w lf (tinsertSz v rt)
-- | Sample data
bt :: BinTree Int
bt = NodeBT 5 (NodeBT 8 (NodeBT 3 Empty Empty) (NodeBT 1 Empty Empty))
              (NodeBT 6 Empty (NodeBT 4 Empty Empty))

test = flipT bt' == Node'' (Node'' (Leaf'' 4) (Leaf'' 3)) (Node'' (Leaf'' 2) (Leaf'' 1))
  && depth bt == 3
  && count bt == 7
  && countDepth bt == (7,3)
  && tsum bt == 27
  && perc 27 bt == bt0
  && comp bt == bt0
  && comp'' bt == comp bt
  && tdouble bt == NodeBT 10 (NodeBT 16 (NodeBT 6 Empty Empty) (NodeBT 2 Empty Empty)) (NodeBT 12 Empty (NodeBT 8 Empty Empty))
  && tcomp bt == 54
  && tcomp' bt == tcomp bt
  && inorder bt == [3, 8, 1, 5, 6, 4]
  && inorder' bt == [3, 8, 1, 5, 6, 4]
  && tinsert 10 bt == NodeBT 5 (NodeBT 8 (NodeBT 3 Empty Empty) (NodeBT 1 Empty Empty)) (NodeBT 6 (NodeBT 10 Empty Empty) (NodeBT 4 Empty Empty))
  && tinsertSz 3 btSz == NodeBTSz (3,3) 5 (NodeBTSz (1,1) 8 (NodeBTSz (0,0) 3 EmptySz EmptySz) (NodeBTSz (0,0) 1 EmptySz EmptySz)) (NodeBTSz (1,1) 6 (NodeBTSz (0,0) 3 EmptySz EmptySz) (NodeBTSz (0,0) 4 EmptySz EmptySz))
  where
    bt0 = NodeBT 0.18518518518518517 (NodeBT 0.2962962962962963 (NodeBT 0.1111111111111111 Empty Empty) (NodeBT 3.7037037037037035e-2 Empty Empty)) (NodeBT 0.2222222222222222 Empty (NodeBT 0.14814814814814814 Empty Empty))
