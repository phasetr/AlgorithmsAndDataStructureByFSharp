-- P.224 9.7 The jogger's problem
module Sec0907 where
import Data.Array (Array,bounds,listArray,(!),(//))
import Lib (apply,maxInt,minWith)
import Sec0901 (Edge,Graph,Vertex,nodes)
import Sec090402 (Links,Weights,gstep,parent,start,weights)
import Sec0906 (distance)

-- P.227
root :: Links -> Vertex -> Vertex
root ls v = if p==1 then v else root ls p where
  p = parent ls v

-- P.227
candidate :: Links -> (Vertex, Vertex) -> Bool
candidate ls (x,y) = if x==1 then parent ls y /= 1
  else root ls x /= root ls y

-- P.227
jog :: Graph -> [Edge]
jog g = getPath ls wa (bestEdge ls wa) where
  ls = fst (apply (n-1) (gstep wa) (start n))
  wa = weights g
  n = length (nodes g)

-- P.227
bestEdge :: Links -> Weights -> (Vertex,Vertex)
bestEdge ls wa =
  minWith cost [(x,y) | x <- [1..n], y <- [x+1..n], candidate ls (x,y)]
  where
    n = snd (bounds ls)
    cost (x,y) = if w == maxInt then maxInt else distance ls x+w+distance ls y
      where w = wa!(x,y)

getPath :: Links -> Weights -> (Vertex,Vertex) -> [Edge]
getPath ls wa (x,y) =
  reverse (path x)++[(x,y,wa!(x,y))]++[(v,u,w) | (u,v,w) <- path y]
  where
    path x = if x == 1 then [] else (p,x,wa!(p,x)):path p
      where p = parent ls x
