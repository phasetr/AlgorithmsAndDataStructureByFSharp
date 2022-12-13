-- P.196, 8.3 Priority queues
module Sec0803 where
import Lib (Nat)
import Sec0801 (Tree(..))
import Sec0802 (Elem,Weight,leaf,node)

-- P.197
data PQ a p = Null | Fork Rank a p (PQ a p) (PQ a p)
type Rank = Nat

-- P.196, P.198
insertQ :: Ord p => a -> p -> PQ a p -> PQ a p
insertQ x p = combineQ (fork x p Null Null)
-- P.196, P.198
deleteQ :: Ord p => PQ a p -> ((a,p),PQ a p)
deleteQ (Fork _ x p t1 t2) = ((x,p), combineQ t1 t2)
deleteQ _ = error "deleteQ: Null"
-- P.196, P.201 Exercise8.19, P.204 Answer8.19
emptyQ :: PQ a p
emptyQ = Null
-- P.196, P.201 Exercise8.19, P.204 Answer8.19
nullQ :: PQ a p -> Bool
nullQ Null = True
nullQ _    = False
-- P.196, P.201 Exercise8.16, P.204 Answer8.17
addListQ :: Ord p => [(a,p)] -> PQ a p -> PQ a p
addListQ xs q = foldr (uncurry insertQ) q xs
-- P.196, P.197
toListQ :: Ord p => PQ a p -> [(a,p)]
toListQ Null = []
toListQ (Fork _ x p t1 t2) = (x,p) : mergeOn snd (toListQ t1) (toListQ t2)

-- P.201, Exercise 8.17, P.204, Answer8.17
mergeOn :: Ord b => (a -> b) -> [a] -> [a] -> [a]
mergeOn key xs [] = xs
mergeOn key [] ys = ys
mergeOn key (x:xs) (y:ys)
  | key x <= key y = x : mergeOn key xs (y:ys)
  | otherwise      = y : mergeOn key (x:xs) ys

-- P.197
fork :: a -> p -> PQ a p -> PQ a p -> PQ a p
fork x p t1 t2
  | r2 <= r1  = Fork (r2+1) x p t1 t2
  | otherwise = Fork (r1+1) x p t2 t1
  where r1 = rank t1; r2 = rank t2

-- P.197
rank :: PQ a p -> Rank
rank Null = 0
rank (Fork r _ _ _ _) = r

-- P.198
combineQ :: Ord p => PQ a p -> PQ a p -> PQ a p
combineQ Null t = t
combineQ t Null = t
combineQ (Fork k1 x1 p1 l1 r1)  (Fork k2 x2 p2 l2 r2)
  | p1 <= p2  = fork x1 p1 l1 (combineQ r1 (Fork k2 x2 p2 l2 r2))
  | otherwise = fork x2 p2 l2 (combineQ (Fork k1 x1 p1 l1 r1) r2)

-- P.198
huffman :: [Elem] -> Tree Elem
huffman = extract . until singleQ gstep . makeQ . map leaf
-- P.198
extract :: PQ (Tree Elem) Weight -> Tree Elem
extract = fst . fst . deleteQ
-- P.198
gstep :: PQ (Tree Elem) Weight -> PQ (Tree Elem) Int
gstep ps = insertQ t w rs
  where
    (t,w) = node p1 p2
    (p1,qs) = deleteQ ps
    (p2,rs) = deleteQ qs
-- P.198
makeQ :: Ord p => [(a,p)] -> PQ a p
makeQ xs = addListQ xs emptyQ
-- P.198
singleQ :: Ord p => PQ a p -> Bool
singleQ = nullQ . snd . deleteQ
