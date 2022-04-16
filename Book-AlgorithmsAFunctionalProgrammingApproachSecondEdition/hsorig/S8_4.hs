module S8_4 where
import PQueue ( emptyPQ, enPQ, frontPQ, pqEmpty )
import Graph ( edgeIn, mkGraph, nodes, weight, Graph )
import Data.Array ( Ix, Array )
import Data.List ( delete )
import Search ( searchGreedy )

-- P.170 8.4 Greedy algorithms
-- Section 8.4.2 SOLVING THE COINS PROBLEM
-- | P.172
coins :: [Coin]
coins = [1,2,5,10,20,50,100]
-- | P.172
type Coin            = Int
-- | P.172
type SolChange       = [Coin]
-- | P.172
type NodeChange      = (Coin, SolChange)
-- | P.172
succCoins :: NodeChange -> [NodeChange]
succCoins (r,p) = [ (r-c,c:p) | c <- coins , r - c >=0 ]
-- | P.172
goalCoins :: NodeChange -> Bool
goalCoins (v,_) = v==0
-- | P.172
change :: Int -> SolChange
change amount = snd(head(searchGreedy succCoins goalCoins (amount,[])))

-- Section 8.4.3 Prim's minimum spanning tree
-- | P.173
type Edge a b    = (a,a,b)
-- | P.173
type NodeMst a b = (b, [a] ,[a], [Edge a b])
-- | P.174
succMst :: (Ix a,Num b,Eq b) => Graph a b -> NodeMst a b -> [NodeMst a b]
succMst g (_,t,r,mst) =
  [(weight x y g, y:t, delete y r, (x,y,weight x y g):mst) |
    x <- t, y <- r, edgeIn g (x,y)]
-- | P.174
goalMst :: (a1, b, [a2], d) -> Bool
goalMst (_,_,[],_) = True
goalMst _          = False
-- | P.174
prim :: (Ord a2, Ix a1, Num a2) => Array (a1, a1) (Maybe a2) -> [Edge a1 a2]
prim g = sol where
  [(_,_,_,sol)] = searchGreedy (succMst g) goalMst (0,[n],ns,[])
  (n:ns) = nodes g

main :: IO ()
main = do
  print $ change 199 == [2,2,5,20,20,50,100]
  print $ prim graphEx == [(2,4,55),(1,3,34),(2,5,32),(1,2,12)]
  where
    graphEx = mkGraph True (1,5) [(1,2,12),(1,3,34),(1,5,78),(2,1,12),(2,5,32),(2,4,55),(3,1,34),(3,5,44),(3,4,61),(4,2,55),(4,3,61),(4,5,93),(5,1,78),(5,2,32),(5,3,44),(5,4,93)]
