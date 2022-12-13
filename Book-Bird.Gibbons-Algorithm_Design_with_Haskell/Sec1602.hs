module Sec1602 where
import qualified Data.Set as S
import Sec0803 (addListQ,nullQ,emptyQ,insertQ)
import Sec1601 (Cost,Heuristic,Graph,Path,Vertex,end,extract,removeQ)
-- P.411 16.2 Searching with a monotonic heuristic

-- P.412
-- empty :: Ord a => Set a
-- member ::Ord a => a -> Set a -> Bool
-- insert :: Ord a => a -> Set a -> Set a
-- P.412
mstar ::Graph -> Heuristic -> (Vertex -> Bool) -> Vertex -> Maybe Path
mstar g h goal source = msearch S.empty start where
  start = insertQ ([source],0) (h source) emptyQ
  msearch vs ps | nullQ ps = Nothing
                | goal (end p) = Just (extract p)
                | seen (end p) = msearch vs qs
                | otherwise = msearch (S.insert (end p) vs) rs
    where
      seen v = S.member v vs
      (p,qs) = removeQ ps
      rs = addListQ (succs g h vs p) qs
succs :: Graph -> Heuristic -> S.Set Vertex -> Path -> [(Path,Cost)]
succs g h vs p = [extend p v d | (v,d) <- g (end p),not (S.member v vs)]
  where extend (vs,c) v d = ((v:vs,c+d),c+d +h v)

-- P.414
-- type PSQ: Priority Search Queue
-- insertQ :: (Ord k,Ord p) => (a -> k) -> a -> p -> PSQ a k p -> PSQ a k p
-- addListQ :: (Ord k,Ord p) => (a -> k) -> [(a,p)] -> PSQ a k p -> PSQ a k p
-- deleteQ :: (Ord k,Ord p) => (a -> k) -> PSQ a k p -> ((a,p),PSQ a k p)
-- emptyQ :: PSQ a k p
-- nullQ :: PSQ a k p -> Bool
