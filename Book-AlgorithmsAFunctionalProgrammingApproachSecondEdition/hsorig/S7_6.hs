module S7_6 where
import Graph ( mkGraph, Graph )
import Search ( Tree(NodeGT), depthFirstTree, dfsforest, kldfsforest, kldfs )

main :: IO ()
main = do
  print $ depthFirstTree 1 g == NodeGT 1 [NodeGT 3 [NodeGT 6 [NodeGT 5 [NodeGT 4 []]]], NodeGT 2 []]
  print $ dfsforest g == [NodeGT 8 [], NodeGT 7 [], NodeGT 1 [NodeGT 3 [NodeGT 6 [NodeGT 5 [NodeGT 4 []]]], NodeGT 2 []]]
  print $ kldfs 1 g == [1,2,3,6,5,4]
  print $ kldfsforest g == [NodeGT 1 [NodeGT 2 [],NodeGT 3 [NodeGT 6 [NodeGT 5 [NodeGT 4 []]]]],NodeGT 7 [],NodeGT 8 []]
  where g = mkGraph True (1,8) [(1,2,0),(1,3,0),(1,4,0),(3,6,0),(5,4,0),(6,2,0),(6,5,0)] :: Graph Integer Integer
