-- P.211, 9.3 Kruskal's algorithm
module Sec0903 where
import Data.List (sortOn)
import Data.Array (Array,listArray,(!),(//))
import Sec0901
import Lib

-- P.211
type Name = Vertex
-- P.212
type Size = Nat
data DS = DS {names :: Array Vertex Vertex
             ,sizes :: Array Vertex Size}

-- P.211, P.213
startDS :: Nat -> DS
startDS n = DS (fromList [1..n]) (fromList (replicate n 1))
-- P.211, P.213
findDS :: DS -> Vertex -> Name
findDS ds x = if x == y then x else findDS ds y
  where y = index (names ds) x
-- P.211, P.213
unionDS :: Name -> Name -> DS -> DS
unionDS n1 n2 ds = DS ns ss
  where (ns,ss) = if s1 < s2
          then (update n1 n2 (names ds),update n2 (s1+s2) (sizes ds))
          else (update n2 n1 (names ds),update n1 (s1+s2) (sizes ds))
        s1 = index (sizes ds) n1
        s2 = index (sizes ds) n2

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

-- P.212
fromList :: [a] -> Array Vertex a
fromList xs = listArray (1, length xs) xs
-- P.212
index :: Array Vertex a -> Vertex -> a
index a v = a!v
-- P.212
update :: Vertex -> a -> Array Vertex a -> Array Vertex a
update v x a = a // [(v,x)]
