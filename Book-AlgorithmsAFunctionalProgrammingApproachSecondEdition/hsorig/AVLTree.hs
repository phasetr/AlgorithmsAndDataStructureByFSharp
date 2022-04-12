module AVLTree(AVLTree(..),emptyAVL,addAVL) where

-- | P.107
data AVLTree a = EmptyAVL | NodeAVL a (AVLTree a) (AVLTree a)
  deriving (Show,Eq)

emptyAVL :: AVLTree a
emptyAVL = EmptyAVL

-- | P.108
rotateLeft,rotateRight :: (Ord a,Show a) => AVLTree a -> AVLTree a
rotateLeft EmptyAVL   = EmptyAVL
rotateLeft (NodeAVL v (NodeAVL lv lflf lfrt) rt)
  = NodeAVL lv lflf (NodeAVL v lfrt rt)
rotateLeft _ = undefined

-- | P.108
rotateRight EmptyAVL  = EmptyAVL
rotateRight (NodeAVL v lf (NodeAVL rv rtlf rtrt))
  = NodeAVL rv (NodeAVL v lf rtlf) rtrt
rotateRight _ = undefined

-- | P.111
dRotateLeftRight, dRotateRightLeft :: (Ord a,Show a) => AVLTree a -> AVLTree a
dRotateRightLeft (NodeAVL v lf
                            (NodeAVL rv (NodeAVL rtlv rtlflf rtlfrt)
                                         rtrt))
  = NodeAVL rtlv (NodeAVL v lf
                            rtlflf)
                 (NodeAVL rv rtlfrt rtrt)
dRotateRightLeft _ = undefined

-- | P.111
dRotateLeftRight (NodeAVL v (NodeAVL lv lflf
                                        (NodeAVL lfrv lfrtlf
                                                      lfrtrt))
                             rt)
  = NodeAVL lfrv (NodeAVL lv lflf lfrtlf)
                 (NodeAVL v lfrtrt rt)
dRotateLeftRight _ = undefined

-- | P.111
height :: (Num p, Show a, Ord a, Ord p) => AVLTree a -> p
height EmptyAVL  = 0
height (NodeAVL _ lf rt) = 1 + max (height lf) (height rt)

-- | P.112
addAVL :: (Ord a, Show a) => a -> AVLTree a -> AVLTree a
addAVL i EmptyAVL= NodeAVL i EmptyAVL EmptyAVL
addAVL i (NodeAVL v lf rt)
  | i < v     =
    let
      newlf@(NodeAVL newlfv _ _)  = addAVL i lf
    in
      if (height newlf - height rt) == 2
      then if i < newlfv
           then rotateLeft (NodeAVL v newlf rt)
           else dRotateLeftRight (NodeAVL v newlf rt)
      else NodeAVL v newlf rt
  | otherwise =
    let newrt@(NodeAVL newrtv _ _)  = addAVL i rt
    in
      if (height newrt - height lf) == 2
      then if i > newrtv
           then rotateRight (NodeAVL v lf newrt)
           else dRotateRightLeft (NodeAVL v lf newrt)
      else NodeAVL v lf newrt
