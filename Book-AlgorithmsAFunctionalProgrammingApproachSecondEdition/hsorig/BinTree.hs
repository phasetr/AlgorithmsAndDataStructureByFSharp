{-# OPTIONS_GHC -Wno-unused-top-binds #-}
module BinTree (BinTree(..),emptyTree,inTree,addTree,delTree,buildTree,inorder) where

inTree    :: (Ord a,Show a) => a -> BinTree a -> Bool
addTree   :: (Ord a,Show a) => a -> BinTree a -> BinTree a
delTree   :: (Ord a,Show a) => a -> BinTree a -> BinTree a
buildTree :: (Ord a,Show a) => [a] -> BinTree a
inorder   :: (Ord a,Show a) => BinTree a -> [a]

data BinTree a = EmptyBT | NodeBT a (BinTree a) (BinTree a) deriving (Show,Eq)

emptyTree :: BinTree a
emptyTree = EmptyBT

btEmpty :: BinTree a -> Bool
btEmpty EmptyBT = True
btEmpty _ = False

inTree v' EmptyBT                  = False
inTree v' (NodeBT v lf rt) | v==v' = True
                           | v'<v  = inTree v' lf
                           | v'>v  = inTree v' rt
inTree _ _ = undefined

addTree v' EmptyBT                      = NodeBT v' EmptyBT EmptyBT
addTree v' (NodeBT v lf rt) | v'==v     = NodeBT v lf rt
                            | v'<v      = NodeBT v (addTree v' lf) rt
                            | otherwise = NodeBT v lf (addTree v' rt)

buildTree = foldr addTree EmptyBT

buildTree' :: Ord a => [a] -> BinTree a
buildTree' [] = EmptyBT
buildTree' lf = NodeBT x (buildTree' l1) (buildTree' l2) where
  l1     = take n lf
  (x:l2) = drop n lf
  n = length lf `div` 2

minTree :: Ord p => BinTree p -> p
minTree (NodeBT v EmptyBT _) = v
minTree (NodeBT _ lf _)      = minTree lf
minTree _ = undefined

-- value not found
delTree v' EmptyBT = EmptyBT
-- one descendant
delTree v' (NodeBT v lf EmptyBT) | v'==v = lf
delTree v' (NodeBT v EmptyBT rt) | v'==v = rt
-- two descendants
delTree v' (NodeBT v lf rt)
  | v'<v  = NodeBT v (delTree v' lf) rt
  | v'>v  = NodeBT v lf (delTree v' rt)
  | v'==v = let k = minTree rt in NodeBT k lf (delTree k rt)
delTree _ _ = undefined

inorder EmptyBT = []
inorder (NodeBT v lf rt) = inorder lf ++ [v] ++ inorder rt

test :: IO ()
test = do
  print (EmptyBT :: BinTree Int)
  print (btEmpty EmptyBT)
  print (addTree 1 EmptyBT == NodeBT 1 EmptyBT EmptyBT)
  print (addTree 1 (addTree 2 EmptyBT) == NodeBT 2 (NodeBT 1 EmptyBT EmptyBT) EmptyBT)
  let t = addTree 1 EmptyBT
  print (inTree 1 t)
  print (not (inTree 2 t))
  -- print (minTree $ buildTree [])
  let t = buildTree [3,2,1]
  print (t == NodeBT 1 EmptyBT (NodeBT 2 EmptyBT (NodeBT 3 EmptyBT EmptyBT)))
  print (inorder t == [1,2,3])
  print (minTree t == 1)
  print (delTree 1 t == NodeBT 2 EmptyBT (NodeBT 3 EmptyBT EmptyBT))
  print (delTree 4 t == NodeBT 1 EmptyBT (NodeBT 2 EmptyBT (NodeBT 3 EmptyBT EmptyBT)))
