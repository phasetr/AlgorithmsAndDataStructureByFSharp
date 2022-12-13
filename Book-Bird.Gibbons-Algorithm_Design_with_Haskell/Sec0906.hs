-- P.220, 9.6 Dijkstra's algorithm
module Sec0906 where
import Data.Array ((!),Array,accum,indices)
import Lib
import Sec0901 (nodes,Tree,Graph,Vertex)
import Sec0903 ()
import Sec090402 (Weights,extract,start,weights)

-- P.220
type State = (Links, [Vertex])
type Links = Array Vertex (Vertex,Distance)
type Distance = Int

-- P.220
parent :: Links -> Vertex -> Vertex
parent ls v = fst (ls!v)
-- P.220
distance :: Links -> Vertex -> Distance
distance ls v = snd (ls!v)

-- P.221
dijkstra :: Graph -> Tree
dijkstra g = extract (apply (n-1) (gstep wa) (start n))
  where
    n = length (nodes g)
    wa = weights g
-- P.221
gstep :: Weights -> State -> State
gstep wa (ls,vs) = (ls',vs') where
  (d,v) = minimum [(distance ls v, v) | v <- vs]
  vs' = filter (/= v) vs
  ls' = accum better ls [(u,(v,sum d (wa!(v,u)))) | u <- vs']
    where sum d w = if w == maxInt then maxInt else d+w
  better (v1,d1) (v2,d2) = if d1<=d2 then (v1,d1) else (v2,d2)

-- P.222
{-
type Path = ([Vertex],Distance)
extract :: State -> [Path]
extract (ls,_) = [(reverse (getPath ls v), distance ls v) | v <- indices ls]
getPath ls v = if u==v then [u] else v:getPath ls u
  where u = parent ls v
-}
