{-# LANGUAGE TupleSections #-}
module S4_3 where

import Data.Array (Ix,Array,bounds,array,(!),indices,ixmap)

{-
P.83
ixmap b f a = array b [(k, a ! f k) | k <- range b]
-}

-- | P.83
row :: (Ix a, Ix b) => a -> Array (a,b) c -> Array b c
row i m = ixmap (l', u') (i,) m
  where ((_,l'),(_,u'))= bounds m
-- | P.83
col :: (Ix a, Ix b) => a -> Array (b,a) c -> Array b c
col j m = ixmap (l, u) (,j) m
  where ((l,_),(u,_))= bounds m

-- | P.83, inner product
inner :: (Ix a, Num b) => Array a b -> Array a b -> b
inner v w = sum [v!i * w!i | i <- indices v]
-- | P.83, multiplication of matrices
matMult :: (Num a, Ix a, Enum a, Num b, Ix b, Num c, Num d, Ix d, Enum d)
        => Array (a,b) c -> Array (b,d) c -> Array (a,d) c
matMult a b = array ((1,1),(m,n))
              [((i,j), inner (row i a) (col j b)) | i<-[1..m],j<-[1..n]]
  where
    ((1,1),(m,_))  = bounds a
    ((1,1),(_,n)) = bounds b

-- | examples of arrays for testing
squares :: (Ix e, Num e, Enum e) => e -> Array e e
squares n = array (1,n) [(i,i*i) | i <- [1..n]]
m :: Array (Integer, Integer) Integer
m = array ((1,1),(2,3)) [((i, j), i*j) | i <- [1..2], j <- [1..3]]
m' :: Array (Integer, Integer) Integer
m'= array ((1,1),(3,2)) [((j, i), i*j) | i <- [1..2], j <- [1..3]]

main = print $ squares 5 == array (1,5) [(1,1), (2,4), (3,9), (4,16), (5,25)]
  && m == array ((1,1),(2,3)) [((1,1),1),((1,2),2),((1,3),3),((2,1),2),((2,2),4),((2,3),6)]
  && fmap (10*) (squares 5) == array (1,5) [(1,10),(2,40),(3,90),(4,160),(5,250)]
  && row 2 m == array (1,3) [(1,2),(2,4),(3,6)]
  && col 2 m == array (1,2) [(1,2),(2,4)]
  && inner (squares 3) (squares 3) == 98
  && matMult m m' == array ((1,1),(2,2)) [((1,1),14),((1,2),28),((2,1),28),((2,2),56)]
