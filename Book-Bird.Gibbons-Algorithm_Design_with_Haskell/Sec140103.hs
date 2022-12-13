module Sec140103 where
import Data.Array ((!),Array,Ix,array,listArray,range)
import Lib (Nat,minWith)
import Sec0801 (splitsn)
import Sec140101 (Tree(..),Cost,Weight,f,g)
import Sec140102 (Triple,cost,weight,tree,fork)

mct :: [Weight] -> Tree Weight
mct ws = tree (table (1,n)) where
  n = length ws
  weights = listArray (1,n) ws
  table (i,j)
    | i==j = (0, weights!i, Leaf (weights!i))
    | i<j = minWith cost [fork (t!(i,k)) (t!(k+1,j)) | k <- [i..j-1]]
    | otherwise = error "undefined"
  t = tabulate table ((1,1),(n,n))

tabulate :: Ix i => (i -> e) -> (i,i) -> Array i e
tabulate f bounds = array bounds [(x, f x) | x <- range bounds]
