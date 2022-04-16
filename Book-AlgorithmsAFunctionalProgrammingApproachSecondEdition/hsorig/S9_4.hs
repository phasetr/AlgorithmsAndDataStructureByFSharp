module S9_4 where
import Data.Array ( Array, (!), listArray )
import Dynamic ( findTable, Table, dynamic )

-- P.185 9.4 Optimal binary search trees
-- | P.187
type ObstCoord  = (Int,Int)
-- | P.187
type ObstEntry  = (Float,Int)
-- | P.187
sumfromto :: Int -> Int-> Array Int Float -> Float
sumfromto i j p = sum [p!l | l<-[i..j]]
-- | P.187
compObst :: Array Int Float -> Table ObstEntry ObstCoord -> ObstCoord -> ObstEntry
compObst p c (i,j)
  | i > j     = (0.0,0)
  | i==j      = (p!i,i)
  | otherwise = addfst (minimum [(fst(findTable c (i,k-1))
                                  + fst(findTable c (k+1,j)), k)
                                | k <- [i..j]])
                (sumfromto i j p)
  where addfst (x,y) z = (x+z,y)

-- | P.187
data BinTree a = EmptyBT | NodeBT a (BinTree a) (BinTree a) deriving (Show,Eq)
-- | P.187
solObst :: Array Int Int -> Table ObstEntry ObstCoord -> ObstCoord -> BinTree Int
solObst keys c (i,j)
  | i > j     = EmptyBT
  | i == j    = NodeBT key EmptyBT EmptyBT
  | otherwise = NodeBT key (solObst keys c (i,k-1))
                (solObst keys c (k+1,j))
  where
    (_,k) = findTable c (i,j)
    key   = keys ! k

-- | P.187
-- these range should be ((1,n),(1,n)) but in compObst
-- indices (i,k-1) and (k+1,j) are needed i<= k <= j
-- adding a supplementary a row and column simplifies testing for
-- the boundary conditions
bndsObst :: Int -> ((Int,Int),(Int,Int))
bndsObst n = ((1,0),(n+1,n))
-- | P.188
obst :: [Int] -> [Float]  -> (BinTree Int,Float)
obst keys ps = (solObst keysA t (1,n) , fst (findTable t (1,n))) where
  n     = length ps
  keysA = listArray (1,n) keys
  psA   = listArray (1,n) ps
  t     = dynamic (compObst psA) (bndsObst n)

main :: IO ()
main =
  print $ obst [1,3,4,8,10,11,15] [0.22,0.18,0.20,0.05,0.25,0.02,0.08] == (NodeBT 4 (NodeBT 1 EmptyBT (NodeBT 3 EmptyBT EmptyBT)) (NodeBT 10 (NodeBT 8 EmptyBT EmptyBT) (NodeBT 15 (NodeBT 11 EmptyBT EmptyBT) EmptyBT)),2.15)

{- Examples of evaluations and results
-- in pretty-printed form
(NodeBT 4 (NodeBT 1 EmptyBT
                    (NodeBT 3 EmptyBT EmptyBT))
          (NodeBT 10 (NodeBT 8 EmptyBT EmptyBT)
                     (NodeBT 15 (NodeBT 11 EmptyBT EmptyBT)
                                EmptyBT)),
 2.15)
-}
