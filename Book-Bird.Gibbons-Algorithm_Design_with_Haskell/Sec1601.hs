module Sec1601 where
import qualified Data.Map as M
import Lib (Nat)
import Sec0803 (PQ,addListQ,deleteQ,emptyQ,insertQ,nullQ)

-- P.406 Searching with an optimistic heuristic
-- P.406
-- Vertex: depends on the application
type Vertex = Nat -- 暫定
type Cost = Nat
type Graph = Vertex -> [(Vertex,Cost)]
type Heuristic = Vertex -> Cost
type Path = ([Vertex],Cost)

-- P.406
end :: Path -> Vertex
end = head . fst
cost :: Path -> Cost
cost = snd
extract :: Path -> Path
extract (vs,c) = (reverse vs,c)

-- P.407
-- insertQ :: Ord p => a -> p -> PQ a p -> PQ a p
-- addListQ :: Ord p => [(a,p)] -> PQ a p -> PQ a p
-- deleteQ :: Ord p => PQ a p -> ((a,p), PQ a p)
-- emptyQ :: PQ a p
-- nullQ :: PQ a p -> Bool
-- P.407
removeQ :: Ord p => PQ a p -> (a, PQ a p)
removeQ q1 = (x,q2) where ((x,_), q2) = deleteQ q1
tstar :: Graph -> Heuristic -> (Vertex -> Bool) -> Vertex -> Maybe Path
tstar g h goal source = tsearch start where
  start = insertQ ([source],0) (h source) emptyQ
  tsearch ps | nullQ ps = Nothing
             | goal (end p) = Just (extract p)
             | otherwise = tsearch rs
    where
      (p,qs) = removeQ ps
      rs = addListQ (succs g h p) qs

-- P.407
succs :: Graph -> Heuristic -> Path -> [(Path,Cost)]
succs g h (u:vs,c) = [((v:u:vs,c+d),c+d +h v) | (v,d) <- g u]
succs _ _ _ = error "undefined"

-- P.410
astar :: Graph -> Heuristic -> (Vertex -> Bool) -> Vertex -> Maybe Path
astar g h goal source = asearch M.empty start where
  start = insertQ ([source],0) (h source) emptyQ
  asearch vcmap ps | nullQ ps = Nothing
                   | goal (end p) = Just (extract p)
                   | better p vcmap = asearch vcmap qs
                   | otherwise = asearch (add p vcmap) rs
    where
      (p,qs) = removeQ ps
      rs = addListQ (succs g h p) qs
better :: Path -> M.Map Vertex Cost -> Bool
better (v:vs,c) vcmap = query (M.lookup v vcmap) where
  query Nothing = False
  query (Just c') = c' <= c
better _ _ = error "undefined"
add :: Path -> M.Map Vertex Cost -> M.Map Vertex Cost
add (v:vs,c) = M.insert v c
add _ = error "undefined"
