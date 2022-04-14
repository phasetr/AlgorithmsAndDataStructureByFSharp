module S7_5 where
import Graph ( mkGraph )
import UnionFind ( kruskal, prim )

main :: IO ()
main = do
  print $ kruskal g == [(55,2,4),(34,1,3),(32,2,5),(12,1,2)]
  print $ kruskal g' == [(32,2,5),(13,1,2),(12,2,4),(11,1,3)]
  print $ prim g == [(55,2,4),(34,1,3),(32,2,5),(12,1,2)]
  print $ prim g' == [(32,2,5),(12,2,4),(13,1,2),(11,1,3)]
  where
    g = mkGraph True (1,5) [(1,2,12),(1,3,34),(1,5,78),(2,4,55),(2,5,32),(3,4,61),(3,5,44),(4,5,93)]
    -- suggested modification by Herbert Kuchen to check that the original
    -- version did not take transitive relation into account
    g' = mkGraph True (1,5) [(1,2,13),(1,3,11),(1,5,78),(2,4,12),(2,5,32),(3,4,14),(3,5,44),(4,5,93)]
