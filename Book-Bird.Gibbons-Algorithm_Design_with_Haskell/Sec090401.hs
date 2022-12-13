module Sec090401 where
import Lib (apply,picks)
import Sec0901 (target,source,edges,nodes,Tree,Edge,Graph,Vertex)

-- P.215, 9.4 Prim's algorithm
type State = (Tree, [Edge])

-- P.215
spats :: Graph -> [Tree]
spats g = map fst (until (all done) (concatMap steps) [start g])
  where done (t,es) = length (nodes t) == length (nodes g)
-- P.215
start :: Graph -> (([Vertex],[Edge]),[Edge])
start g = (([head (nodes g)], []), edges g)
-- P.215
steps :: State -> [State]
steps (t,es) = [(add e t, es') | (e,es') <- picks es, safeEdge e t]
-- P.215
safeEdge :: Edge -> Tree -> Bool
safeEdge e t = elem (source e) (nodes t) /= elem (target e) (nodes t)
-- P.215
add :: Edge -> Tree -> Tree
add e (vs,es) = if source e `elem` vs
  then (target e:vs, e:es)
  else (source e:vs, e:es)

{-
P.216
MCC = MinWith cost . map fst . until (all done) (concatMap steps) . wrap
extract (until done gstep sx) <- MCC sx
t <- MCC (gstep sx) && t <- MCC sx
-}
gstep (t,e:es) = if safeEdge e t then (add e t,es) else keep e (gstep (t,es))
  where keep e (t,es) = (t,e:es)
gstep _ = error "gstep: Do not come here"

-- P.216
prim1 :: Graph -> Tree
prim1 g = fst $ until done gstep (start g)
  where done (t,es) = length (nodes t) == length (nodes g)
-- P.216
prim2 :: Graph -> Tree
prim2 g = fst (apply (n-1) gstep (start g))
  where n = length (nodes g)
