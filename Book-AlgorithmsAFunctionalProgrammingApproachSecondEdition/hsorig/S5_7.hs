module S5_7 where
import BinTree
    ( buildTree,
      BinTree(EmptyBT, NodeBT),
      addTree,
      delTree,
      emptyTree,
      inTree )

main :: IO ()
main = do
  print $ f5_6 == NodeBT 5 (NodeBT 2 EmptyBT (NodeBT 4 (NodeBT 3 EmptyBT EmptyBT) EmptyBT)) (NodeBT 6 EmptyBT (NodeBT 8 EmptyBT (NodeBT 9 EmptyBT EmptyBT)))
  print $ inTree 9 fig5_6
  print $ inTree 9 f5_6
  print $ delTree 5 f5_6 == NodeBT 6 (NodeBT 2 EmptyBT (NodeBT 4 (NodeBT 3 EmptyBT EmptyBT) EmptyBT)) (NodeBT 8 EmptyBT (NodeBT 9 EmptyBT EmptyBT))
  print $ addTree 1 f5_6 == NodeBT 5 (NodeBT 2 (NodeBT 1 EmptyBT EmptyBT) (NodeBT 4 (NodeBT 3 EmptyBT EmptyBT) EmptyBT)) (NodeBT 6 EmptyBT (NodeBT 8 EmptyBT (NodeBT 9 EmptyBT EmptyBT)))
  print $ foldr addTree emptyTree (reverse [5,2,4,3,8,6,7,10,9,11])
  where
    fig5_6 = buildTree (reverse [5,2,4,3,8,6,7,10,9,11])
    f5_6 = buildTree (reverse [5,2,6,4,8,3,9])
