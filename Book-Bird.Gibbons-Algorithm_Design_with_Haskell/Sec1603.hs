module Sec1603 where
import Data.Array (listArray,(!),(//))
import qualified Data.Set as S
import Lib (Nat)
-- P.415 16.3 Navigating a warehouse
-- P.417
type Coord = Nat
type Vertex = (Coord,Coord)
type Box = Vertex
type Grid = (Nat,Nat,[Box])
boxes :: Grid -> [Box]
boxes (_,_,bs) = bs
corners :: Box -> [Vertex]
corners (x,y) = [(x,y),(x+1,y),(x+1,y-1),(x,y-1)]

-- P.417
type Graph = Vertex -> [Vertex]
neighbours :: Grid -> Graph
neighbours grid = filter (free grid) . adjacents
adjacents :: Vertex -> [Vertex]
adjacents (x,y) = [(x-1,y-1),(x-1,y),(x-1,y+1),
                   (x, y-1),         (x,y+1),
                   (x+1,y-1),(x+1,y),(x+1,y+1)]
free :: Grid -> Vertex -> Bool
free (m,n,bs) = (a!)
  where a = listArray ((0,0),(m+1,n+1)) (repeat True)
          // [((x,y),False) | x <- [0..m+1], y <- [0,n+1]]
          // [((x,y),False) | x <- [0,m+1], y <- [1..n]]
          // [((x,y),False) | b <- bs, (x,y) <- corners b]

-- P.417
type Dist = Float
type Path = ([Vertex],Dist)
end :: Path -> Vertex
end = head . fst

-- P.418
extract :: Path -> Path
extract (vs,d) = (reverse vs,d)
fpath :: Grid -> Vertex -> Vertex -> Maybe Path
fpath grid = mstar (neighbours grid)
-- mstar :: Graph -> Vertex -> Vertex -> Maybe Path

-- P.418
-- succs :: Graph -> Vertex -> S.Set Vertex -> Path -> [(Path,Dist)]
-- succs g target visited p =
--   [extend p v | v <- g (end p),not (S.member v visited)]
--   where extend (u:vs,d) v = ((v:u:vs,dv),dv+dist v target)
--           where dv = d +dist u v

-- P.418
-- visible :: Grid -> Segment -> Bool
type Segment = (Vertex,Vertex)

-- P.419
-- vpath :: Grid -> Vertex -> Vertex -> Maybe Path
-- vpath grid = mstar (neighbours grid) (visible grid)
  -- mstar :: Graph → (Segment → Bool) → Vertex → Vertex → Maybe Path

-- succs g vtest target vs p =
--   [extend p w | w <- g (end p),not (S.member w vs)]
--   where extend (v:vs,d) w =
--           if not (null vs) && vtest (u,w)
--           then ((w:vs,du),du+dist w target)
--           else ((w:v:vs,dw),dw+dist w target)
--           where
--             u = head vs
--         du = d-dist u v+dist u w
--         dw = d+dist v w
