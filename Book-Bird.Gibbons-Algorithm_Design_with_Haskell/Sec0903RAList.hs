-- P.211, 9.3 Kruskal's algorithm
module Sec0903RAList where
import Data.List (sortOn)
import Data.Array (Array,listArray,(!),(//))
import Sec0302 (Digit,RAList,lookupRA,toRA,updateRA)
import Sec0901 (Vertex,Edge,Graph,Tree,nodes,edges,source,target,weight)
import Sec0903 (Name,Size)
import Lib (Nat,apply)

data DS = DS {names :: RAList Vertex
             ,sizes :: RAList Size}

-- P.214
startDS :: Nat -> DS
startDS n = DS (toRA [1..n]) (toRA (replicate n 1))
-- P.211, P.213
findDS :: DS -> Vertex -> Name
findDS = undefined -- TODO!
--findDS ds x = if x == y then x else findDS ds y
--  where y = index (names ds) x
-- P.211, P.213
unionDS :: Name -> Name -> DS -> DS
unionDS = undefined -- TODO
--unionDS n1 n2 ds = DS ns ss
--  where (ns,ss) = if s1 < s2
--          then (update n1 n2 (names ds), update n2 (s1+s2) (sizes ds))
--          else (update n2 n1 (names ds), update n1 (s1+s2) (sizes ds))
--        s1 = index (sizes ds) n1
--        s2 = index (sizes ds) n2

-- P.211
type State = (DS,[Edge],[Edge])
-- P.211
kruskal :: Graph -> Tree
kruskal g = extract (apply (n-1) gstep s)
  where
    extract (_,es,_) = (nodes g, es)
    n = length (nodes g)
    s = (startDS n, [], sortOn weight (edges g))

    gstep :: State -> State
    gstep (ds,fs,e:es) =
      if n1 /= n2 then (unionDS n1 n2 ds, e:fs, es)
      else gstep (ds,fs,es)
      where
        n1 = findDS ds (source e)
        n2 = findDS ds (target e)
    gstep _ = error "gstep: error"

-- P.215
index :: RAList Vertex -> Nat -> Digit Vertex
index xs x = lookupRA (x-1) xs
-- P.215
update :: Vertex -> Nat -> RAList Vertex -> RAList Vertex
update n1 = updateRA (n1-1)
