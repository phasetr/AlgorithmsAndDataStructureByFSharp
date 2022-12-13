module Sec090402 where
import Data.Array ((//),(!),Array,accum,array,assocs,indices,listArray)
import Lib (apply,Nat)
import Sec0901 (edges,nodes,Tree,Graph,Vertex,Weight)

-- P.217
type State = (Links,[Vertex])
type Links = Array Vertex (Vertex,Weight)
-- P.217
parent :: Links -> Vertex -> Vertex
parent ls v = fst (ls ! v)
-- P.P217
weight :: Links -> Vertex -> Weight
weight ls v = snd (ls ! v)

-- P.218
type Weights = Array (Vertex,Vertex) Weight
-- P.230 Exercise9.9, P.233 Answer9.9
weights :: Graph -> Weights
weights g = listArray ((1,1), (n,n)) (repeat maxInt)
  // [((u,v),w) | (u,v,w) <- edges g]
  // [((v,u),w) | (u,v,w) <- edges g]
  where n = length (nodes g)
-- P.230 Exercise9.9, P.233 Answer9.9
weightsDirected :: Graph -> Weights
weightsDirected g = listArray ((1,1), (n,n)) (repeat maxInt)
  // [((u,v),w) | (u,v,w) <- edges g]
  where n = length (nodes g)

-- P.218
prim3 :: Graph -> Tree
prim3 g = extract (apply (n-1) (gstep wa) (start n))
  where
    n = length (nodes g)
    wa = weights g
-- P.218
start :: Nat -> State
start n = (array (1,n) ((1,(1,0)):[(v,(v,maxInt)) | v <- [2..n]]), [1..n])
-- P.218
maxInt :: Int
maxInt = maxBound
-- P.218
gstep :: Weights -> State -> State
gstep wa (ls,vs) = (ls',vs') where
  (_,v) = minimum [(weight ls v, v) | v <- vs]
  vs' = filter (/= v) vs
  ls' = accum better ls [(u,(v,wa!(u,v))) | u <- vs']
  better (v1,w1) (v2,w2) = if w1 <= w2 then (v1,w1) else (v2,w2)
-- P.219
extract :: State -> Tree
extract (ls,_) = (indices ls, [(u,v,w) | (v,(u,w)) <- assocs ls, v /= 1])
