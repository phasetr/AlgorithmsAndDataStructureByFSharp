module Sec140102 where
import Lib (Nat,minWith)
import Sec0801 (splitsn)
import Sec140101 (Tree(..),Cost,Weight,f,g)
-- P.338
type Triple = (Cost,Weight,Tree Weight)
cost :: (a, b, c) -> a
cost (a,_,_) = a
weight :: (a, b, c) -> b
weight (_,b,_) = b
tree :: (a, b, c) -> c
tree (_,_,c) = c

mct :: [Weight] -> Tree Weight
mct = tree . triple
triple :: [Weight] -> Triple
triple [w] = (0,w,Leaf w)
triple ws = minWith cost [fork (triple us) (triple vs)
                         | (us,vs) <- splitsn ws]
fork :: Triple -> Triple -> Triple
fork (c1,w1,t1) (c2,w2,t2) = (c1+c2+f w1 w2, g w1 w2, Fork t1 t2)
table :: (Int,Int) -> [Weight] -> Triple
table (i,j) = triple . drop (i-1) . take j
