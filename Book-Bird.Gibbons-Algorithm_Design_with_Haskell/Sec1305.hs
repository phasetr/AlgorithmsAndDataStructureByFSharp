module Sec1305 where
import Lib (Nat,apply,minWith)
-- P.323 13.5 The shuttle-bus problem

-- P.323
type Passengers = [(Count,Stop)]
type Count = Nat
type Stop = Nat
type Leg = (Stop,Stop)

-- P.324
cost :: Passengers -> [Leg] -> Nat
cost ps [] = 0
cost ps ((x,y):ls) = legcost qs (x,y)+cost rs ls where
  (qs,rs) = span (atmost y) ps
legcost :: (Num a, Ord a) => [(a, a)] -> (a, a) -> a
legcost ps (x,y) = sum [c * min (s-x) (y-s) | (c,s) <- ps]
atmost :: Ord a1 => a1 -> (a2, a1) -> Bool
atmost y (c,s) = s <= y

{-
-- P.324
schedule :: Nat -> Nat -> Passengers -> [Leg]
schedule n k ps ← MinWith (cost ps) (legs n k 0)
-}
-- P.324
legs :: Nat -> Nat -> Stop -> [[Leg]]
legs n k x
  | x == n = [[]]
  | k == 0 = [[(x,n)]]
  | otherwise = [(x,y):ls | y <- [x+1..n], ls <- legs n (k-1) y]

-- P.325
schedule :: (Eq t, Num t) => Int -> t -> [(Count, Stop)] -> [(Stop, Stop)]
schedule n k ps = process ps k 0 where
  process ps k x
    | x == n = []
    | k == 0 = [(x,n)]
    | otherwise = minWith (cost ps) [ (x,y):process (cut y ps) (k-1) y
                                    | y <- [x+1..n]]
cut :: Ord a1 => a1 -> [(a2, a1)] -> [(a2, a1)]
cut y = dropWhile (atmost y)

{-
P.325
table ps k = [process (cut x ps) k x | x ← [0..n]]
In particular,
schedule n k ps = head (table ps k)
The bottom row of the table is given by
table ps 0 = [[(x,n)] | x ← [0..n?1]]++[[ ]]
It remains to show how table ps k is computed from table ps (k ?1). The idea is to
define step so that
table ps k = step (table ps (k ?1))
-}

-- P.325
ptails :: [a] -> [[a]]
ptails [] = []
ptails (x:xs) = xs:ptails xs
schedule2 n k ps = head (apply k step start) where
  start = [[(x,n)] | x <- [0..n-1]]++[[ ]]
  step t = zipWith entry [0..n-1] (ptails t)++[[ ]]
  entry x ts = minWith (cost (cut x ps))
               (zipWith (:) [(x,y) | y <- [x+1..n]] ts)
