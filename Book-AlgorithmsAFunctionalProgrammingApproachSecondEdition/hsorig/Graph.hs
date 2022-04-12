module Graph(Graph(..),mkGraph,adjacent,nodes,edgesU,edgesD,edgeIn,weight) where
import Data.Array ( Ix(range), Array, bounds, array, (!), (//) )
import Data.Maybe ( isJust )

mkGraph :: (Ix n,Num w) => Bool -> (n,n) -> [(n,n,w)] -> Graph n w
adjacent :: (Ix n,Num w,Eq w) => Graph n w -> n -> [n]
nodes :: (Ix n,Num w) => Graph n w -> [n]
edgesU :: (Ix n,Num w,Eq w) => Graph n w -> [(n,n,w)]
edgesD :: (Ix n,Num w,Eq w) => Graph n w -> [(n,n,w)]
edgeIn :: (Ix n,Num w,Eq w) => Graph n w -> (n,n) -> Bool
weight :: (Ix n,Num w) => n -> n -> Graph n w -> w

-- | Adjacency matrix representation
type Graph n w = Array (n,n) (Maybe w)

mkGraph dir bnds@(l,u) es =
  emptyArray // ([((x1,x2),Just w) |(x1,x2,w)<-es] ++
                  if dir then []
                  else [((x2,x1),Just w) |(x1,x2,w)<-es,x1/=x2])
  where emptyArray = array ((l,l),(u,u)) [((x1,x2),Nothing) |
                                          x1 <- range bnds,
                                           x2 <- range bnds]
adjacent g v1 = [ v2 | v2 <-nodes g, edgeIn g (v1,v2)]
nodes g       = range (l,u) where ((l,_),(u,_)) = bounds g
edgeIn g (x,y)= isJust (g!(x,y))
weight x y g  = w where (Just w) = g!(x,y)
edgesD g      = [(v1,v2,unwrap(g!(v1,v2))) |
                 v1 <-nodes g, v2 <- nodes g, edgeIn g (v1,v2)]
edgesU g      = [(v1,v2,unwrap(g!(v1,v2))) |
                 v1 <-nodes g, v2 <- range (v1,u),
                  edgeIn g (v1,v2)]
  where (_,(u,_)) = bounds g

unwrap :: Maybe p -> p
unwrap (Just w) = w
unwrap Nothing = error "unwrap error"
