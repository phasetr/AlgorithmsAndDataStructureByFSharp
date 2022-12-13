module Sec1402 where
import Data.Array ((!),listArray)
import Lib (Nat,minWith)
import Sec140101 (Cost,Tree(..),Weight,f,g)
import Sec140103 (tabulate)

type Root = Nat
type Quartet = (Root,Cost,Weight,Tree Weight)
-- P.339 14.2 A quadratic-time algorithm
root :: (a, b, c, d) -> a
root (a,_,_,_) = a
cost :: (a, b, c, d) -> b
cost (_,b,_,_) = b
weight :: (a, b, c, d) -> c
weight (_,_,c,_) = c
tree :: (a, b, c, d) -> d
tree (_,_,_,d) = d

mct :: [Weight] -> Tree Weight
mct ws = tree (table (1,n)) where
  n = length ws
  weights = listArray (1,n) ws
  table (i,j)
    | i==j = (i, 0, weights!i, Leaf (weights!i))
    | i+1==j = fork i (t!(i,i)) (t!(j,j))
    | i+1<j = minWith cost [fork k (t!(i,k)) (t!(k+i,j))
                           | k <- [r (i,j-1)..r(i+1,j)]]
    | otherwise = error "undefined"
  r (i,j) = root (t!(i,j))
  t = tabulate table ((1,1),(n,n))

fork :: Root -> Quartet -> Quartet -> Quartet
fork k (_,c1,w1,t1) (_,c2,w2,t2) = (k, c1+c2+f w1 w2, g w1 w2, Fork t1 t2)
