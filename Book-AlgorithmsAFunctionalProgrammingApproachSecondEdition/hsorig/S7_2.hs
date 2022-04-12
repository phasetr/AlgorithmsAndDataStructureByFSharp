module S7_2 where
import Data.Array ( array )
import qualified Graph as G
import qualified GraphAdjacencyList as GAL

main :: IO ()
main = print $ GAL.adjacent graphAL 4 == [2,3,5]
  && GAL.adjacent graphAL 4 == [2,3,5]
  && GAL.nodes graphAL == [1..5]
  && GAL.edgesD graphAL == [(1,2,12),(1,3,34),(1,5,78),(2,1,12),(2,4,55),(2,5,32),(3,1,34),(3,4,61),(3,5,44),(4,2,55),(4,3,61),(4,5,93),(5,1,78),(5,2,32),(5,3,44),(5,4,93)]
  && GAL.edgesU graphAL == [(1,2,12),(1,3,34),(1,5,78),(2,4,55),(2,5,32),(3,4,61),(3,5,44),(4,5,93)]
  && not (GAL.edgeIn graphAL (3,2))
  && GAL.edgeIn graphAL (3,4)
  && GAL.weight 3 4 graphAL == 61
  && GAL.mkGraph True (1,5) [(1,2,10),(1,3,20),(2,4,30),(3,4,40),(4,5,50)] == array (1,5) [(1,[(3,20),(2,10)]),(2,[(4,30)]),(3,[(4,40)]),(4,[(5,50)]),(5,[])]
  && G.adjacent graphAM 4 == [5]
  && G.nodes graphAM == [1..5]
  && G.edgesD graphAM == [(1,2,10),(1,3,20),(2,4,30),(3,4,40),(4,5,50)]
  && G.edgesU graphAM == [(1,2,10),(1,3,20),(2,4,30),(3,4,40),(4,5,50)]
  && not (G.edgeIn graphAM (3,2))
  && G.edgeIn graphAM (3,4)
  && G.weight 3 4 graphAM == 40
  where
    graphAM = G.mkGraph True (1,5) [(1,2,10),(1,3,20),(2,4,30),(3,4,40),(4,5,50)]
    graphAL = array (1,5) [(1,[(2,12),(3,34),(5,78)]),
                           (2,[(1,12),(4,55),(5,32)]),
                           (3,[(1,34),(4,61),(5,44)]),
                           (4,[(2,55),(3,61),(5,93)]),
                           (5,[(1,78),(2,32),(3,44),(4,93)])]

    -- same graph but created with mkGraph but different ordering of arcs
    graphAL' = GAL.mkGraph False (1,5) [(1,2,12),(1,3,34),(1,5,78),
                                        (2,4,55),(2,5,32),
                                        (3,4,61),(3,5,44),
                                        (4,5,93)]
