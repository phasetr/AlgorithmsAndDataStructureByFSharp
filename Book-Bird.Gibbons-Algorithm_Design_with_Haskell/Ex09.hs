module Ex09 where
import Data.Array
import Data.List (sortOn)
import Lib (minWith,tails)
import Sec0901 (AdjArray,Forest,Graph,Tree,edges,nodes,weight)
import Sec0902 (add,safeEdge)

-- P.229, Exercise9.2, P.232 Answer9.2
toAdj :: Graph -> AdjArray
toAdj g = accumArray (flip (:)) [] (1,n) [(u,(v,w)) | (u,v,w) <- edges g]
  where n = length (nodes g)

toGraph :: AdjArray -> Graph
toGraph a = (indices a, [(u,v,w) | (u,vws) <- assocs a, (v,w) <- vws])

-- P.230 Exercise9.6, P.232 Answer9.6
steps :: State -> [State]
steps (ts,es) = [(add e ts,es') | e:es' <- tails es, safeEdge e ts]

-- P.230 Exercise9.7, P.233 Answer9.7
-- TODO gstepを適切な箇所からimportする
mcsf :: Graph -> Forest
mcsf g = fst (until (null . snd) gstep s)
  where s = ([([v],[]) | v <- nodes g], sortOn weight (edges g))

-- P.230 Exercise9.8, P.233 Answer9.8
notEqual :: Tree -> Tree -> Bool
notEqual t1 t2 = head (nodes t1) /= head (nodes t2)

-- P.230 Exercise9.9, P.233 Answer9.9
weights g = listArray ((1,1),(n,n)) (repeat maxInt)
  // [((u,v),w) | (u,v,w) <- edges g]
  // [((v,u),w) | (u,v,w) <- edges g]
  where n = length (nodes g)

weightsDirected :: Graph -> Array (Vertex,Vertex) Weight
weightsDirected g = listArray ((1,1),(n,n)) (repeat maxInt)
  // [((u,v),w) | (u,v,w) <- edges g]
  where n = length (nodes g)

-- P.230 Exercise9.10, P.233 Answer9.10
maxWith cost = minWith newcost
newcost ::Tree -> Int
newcost = sum . map (negate . weight) . edges

-- P.230 Exercise9.11, P.233 Answer9.11
spats :: Graph -> [Tree]
spats g = map fst (apply (n?1) (concatMap steps) [s])
  where
    n = length (nodes g)
    s = (([head (nodes g)],[ ]),edges g)

    steps :: (Tree,[Edge]) -> [(Tree,[Edge])]
    steps (t,es) = [(add e t,es') | (e,es') <- picks es, safeEdge e t]

    add  :: Edge -> Tree -> Tree
    add e (vs,es) = (target e:vs,e:es)

    safeEdge :: Edge -> Tree -> Bool
    safeEdge e t = elem (source e) ns && target e `notElem` ns
      where ns = nodes t

    pathsFrom u t =
      [] : [(u,v,w):es | (u',v,w) <- edges t,u' == u,es <- pathsFrom v t]

    cost = map (sum . map weight) . sortOn (target  . last) . tail . pathsFrom 1

-- P.231 Exercise9.14, P.235 Answer9.14
dijkstra :: Graph -> Vertex -> Path
dijkstra g v = path (until done (gstep wa) (start n))
  where
    path (ls,vs) = (reverse (getPath ls v),distance ls v)
    done (ls,vs) = v `notElem` vs
    n = length (nodes g)
    wa = weights g

-- P.231 Exercise9.15, P.235 Answer9.15
gstep :: Weights -> State -> State
gstep wa (ls,vs) = (ls′,vs′) where
  (d,v) = minimum [(distance ls v,v) | v ← vs]
  vs' = filter (?= v) vs
  ls' = accum better ls [(u,(v,new u,sum d (wa!(v,u)))) | u ← vs']
    where sum d w = if w == maxInt then maxInt else d +w
  better (v1,r1,d1) (v2,r2,d2) =
    if d1 <= d2 then (v1,r1,d1) else (v2,r2,d2)
  new u = if v == 1 then u else root ls v
