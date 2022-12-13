-- P.208, 9.2 Kruskal's algorithm
module Sec0902 where
import Data.List (sortOn)
import Data.Array (Array)
import Sec0901
import Lib (apply,picks,single,wrap)

-- P.208
type State = (Forest, [Edge])
-- P.208
spats :: Graph -> [Tree]
spats = map extract . until (all done) (concatMap steps) . wrap . start
-- P.208
extract :: State -> Tree
extract ([t], _) = t
extract _ = error "extract: error"
-- P.208
done :: State -> Bool
done = single . fst
-- P.208
start :: Graph -> State
start g = ([([v],[]) | v <- nodes g], edges g)
-- P.209
steps :: State -> [State]
steps (ts,es) = [(add e ts, es') | (e,es') <- picks es, safeEdge e ts]
-- P.209
safeEdge :: Edge -> Forest -> Bool
safeEdge e ts = find ts (source e) /= find ts (target e)
-- P.209
find :: Forest -> Vertex -> Tree
find ts v = head [t | t <- ts, v `elem` nodes t]
-- P.209
add :: Edge -> Forest -> Forest
add e ts = (nodes t1 ++ nodes t2, e : edges t1 ++ edges t2) : rest
  where
    t1 = find ts (source e)
    t2 = find ts (target e)
    rest = [t | t <- ts, t /= t1 && t /= t2]

{-
P.210
MCC = MinWith cost ・map extract ・until (all done) (concatMap steps)・wrap
extract (until done gstep sx) ← MCC sx
done sx ⇒ extract sx ← MCC sx
extract ([t],es) = t ← MCC ([t],es)
t ← MCC (gstep sx) ∧ t ← MCC sx
-}

-- P.210
gstep :: State -> State
gstep (ts, e:es) = if t1 /= t2 then (ts',es) else gstep (ts,es)
  where
    t1 = find ts (source e)
    t2 = find ts (target e)
    ts' = (nodes t1 ++ nodes t2, e : edges t1 ++ edges t2) : rest
    rest = [t | t <- ts, t /= t1 && t /= t2]
gstep _ = error "gstep: error"

-- P.210
kruskal1 :: Graph -> Tree
kruskal1 = extract . until done gstep . start
  where
    start g = ([([v],[]) | v <- nodes g], sortOn weight (edges g))

-- P.210
kruskal2 :: Graph -> Tree
kruskal2 g = extract (apply (n-1) gstep (start g))
  where n = length (nodes g)
