module S5_9 where

import AVLTree ( AVLTree(EmptyAVL, NodeAVL), emptyAVL, addAVL )

main = print
  $ foldr addAVL emptyAVL [7,6..1]
  == NodeAVL 4 (NodeAVL 2 (NodeAVL 1 EmptyAVL EmptyAVL) (NodeAVL 3 EmptyAVL EmptyAVL)) (NodeAVL 6 (NodeAVL 5 EmptyAVL EmptyAVL) (NodeAVL 7 EmptyAVL EmptyAVL))
