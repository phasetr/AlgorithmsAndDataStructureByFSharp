module S9_6 where
-- to get access to the imported modules in Hugs do
-- :set -P../Chapter7:../Chapter5:{Hugs}/lib:{Hugs}/lib/hugs:{Hugs}/lib/exts

import Dynamic
import Graph

-- implementation of a Set with an Int 
-- open and concrete version of the bit string implementation of the ADT Set
-- check bounds only for fullset which is called at the start of the TSP

type Set = Int

emptySet = 0

setEmpty n = n==0

fullSet n | (n>=0) && (n<=maxSet) = 2^(n+1)-2 -- element 0 is not there...
          | otherwise = error ("fullset:illegal set =" ++ show n)

addSet i s = d'*e+m
    where (d,m) = divMod s e
          e  = 2^i
          d' = if odd d then d else d+1

delSet i s = d'*e+m
    where (d,m) = divMod s e
          e = 2^i
          d' = if odd d then d-1 else d

set2List s = s2l s 0
    where s2l 0 _             = []
          s2l n i | odd n     = i : s2l (n `div` 2) (i+1)
                  | otherwise = s2l (n `div` 2) (i+1)

maxSet = truncate (logBase 2 (fromInt (maxBound::Int))) - 1

-- start of TSP

type TspCoord = (Int,Set)
type TspEntry = (Int,[Int])

compTsp :: Graph Int Int -> Int -> Table TspEntry TspCoord 
                         -> TspCoord -> TspEntry 
compTsp g n a (i,k) 
    | setEmpty k = (weight i n g,[i,n])
    | otherwise = minimum [ addFst (findTable a (j, delSet j k))
                                   (weight i j g)
                            | j <- set2List k]
    where addFst (c,p) w = (w+c,i:p)

bndsTsp   :: Int -> ((Int,Set),(Int,Set))
bndsTsp n =  ((1,emptySet),(n,fullSet n))

tsp   :: Graph Int Int -> (Int,[Int])
tsp g = findTable t (n,fullSet (n-1))
    where n = length (nodes g)
          t = dynamic (compTsp g n) (bndsTsp n)

-- examples of graphs 

dm::Graph Int Int
dm = mkGraph True (1,6) [(i,j,(v1!!(i-1))!!(j-1)) |i<-[1..6],j<-[1..6]]
v1::[[Int]]
v1 =[[  0,  4,  1,  6,100,100],
     [  4,  0,  1,100,  5,100],
     [  1,  1,  0,100,  8,  2],
     [  6,100,100,  0,100,  2],
     [100,  5,  8,100,  0,  5],
     [100,100,  2,  2,  5,  0]]

oldbrassardP103 :: Graph Int Int
oldbrassardP103
    = mkGraph True (1,6) [(i,j,(v'!!(i-1))!!(j-1)) |i<-[1..6],j<-[1..6]]
v'::[[Int]]
v' =  [[  0,  3, 10, 11,  7, 25],
       [  3,  0,  6, 12,  8, 26],
       [ 10,  6,  0,  9,  4, 20],
       [ 11, 12,  9,  0,  5, 15],
       [  7,  8,  4,  5,  0, 18],
       [ 25, 26, 20, 15, 18,  0]]


{- Examples of evaluations and results 

? tsp dm
(20, [6, 4, 1, 3, 2, 5, 6])
? tsp oldbrassardP103
(56, [6, 3, 2, 1, 5, 4, 6])

-}
