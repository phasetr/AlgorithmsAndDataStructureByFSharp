module S7_3 where
import Data.Array ( Ix )
import Graph ( adjacent, mkGraph, Graph )
import Queue ()
import Stack ()
import qualified Search

-- P.140, 7.3 Depth-first and breadth-first search

-- | P.142, 7.3.1 Depth-first search
depthFirstSearch :: (Ix a, Num b, Eq b) => a -> Graph a b -> [a]
depthFirstSearch start g = dfs [start] [] where
  dfs [] vis    = vis
  dfs (c:cs) vis
    | c `elem` vis = dfs cs vis
    | otherwise  = dfs (adjacent g c++cs) (vis++[c])

-- | P.142, avoid one `++` operator
depthFirstSearch' :: (Ix a, Num b, Eq b) => a -> Graph a b -> [a]
depthFirstSearch' start g = reverse (dfs [start] []) where
  dfs [] vis     = vis
  dfs (c:cs) vis
    | c `elem` vis = dfs cs vis
    | otherwise  = dfs (adjacent g c++cs) (c:vis)

main :: IO ()
main = print $ depthFirstSearch 1 g == res
  && depthFirstSearch' 1 g == res
  && Search.depthFirstSearch 1 g == res
  && Search.breadthFirstSearch 1 g == [1,4,3,2,6,5]
  where
    g = mkGraph True (1,6) [(1,2,0),(1,3,0),(1,4,0),(3,6,0),(5,4,0),(6,2,0),(6,5,0)]
    res = [1,2,3,6,5,4]
