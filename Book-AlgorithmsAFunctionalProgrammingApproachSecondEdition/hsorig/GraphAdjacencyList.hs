module GraphAdjacencyList(Graph(..),mkGraph,adjacent,nodes,edgesU,edgesD,edgeIn,weight) where
import Data.Array ( Ix, Array, array, (!), accumArray, indices )

mkGraph :: (Ix n,Num w) => Bool -> (n,n) -> [(n,n,w)] -> Graph n w
adjacent :: (Ix n,Num w,Eq w) => Graph n w -> n -> [n]
nodes :: (Ix n,Num w) => Graph n w -> [n]
edgesU :: (Ix n,Num w,Eq w) => Graph n w -> [(n,n,w)]
edgesD :: (Ix n,Num w,Eq w) => Graph n w -> [(n,n,w)]
edgeIn :: (Ix n,Num w,Eq w) => Graph n w -> (n,n) -> Bool
weight :: (Ix n,Num w) => n -> n -> Graph n w -> w

-- | Adjacency list representation
type Graph n w = Array n [(n,w)]

mkGraph dir bnds es =
  accumArray (flip (:)) [] bnds
  ([(x1,(x2,w)) | (x1,x2,w) <- es] ++
    if dir then []
    else [(x2,(x1,w))|(x1,x2,w)<-es,x1/=x2])

adjacent g v   = map fst (g!v)
nodes          = indices
edgeIn g (x,y) = y `elem` adjacent g x
weight x y g   = head [ c | (a,c)<-g!x , a==y]
edgesD g       = [(v1,v2,w) | v1<- nodes g , (v2,w) <-g!v1]
edgesU g       = [(v1,v2,w) | v1<- nodes g , (v2,w) <-g!v1 , v1 < v2]
