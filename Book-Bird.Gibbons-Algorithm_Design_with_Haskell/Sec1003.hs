-- P.248 10.3 Coin-changing revisited
module Sec1003 where
import Lib (Nat,minWith)
import qualified Distribution.SPDX as P

-- P.248
ukds = [1,2,5,10,20,50,100,200]
urds = [1,2,5,15,20,50,100]

-- P.248
type Denom = Nat
type Coin = Nat
type Residue = Nat
type Count = Nat
type Tuple = ([Coin],Residue,Count)

-- P.249
coins :: Tuple -> [Coin]
coins (cs,_,_) = cs

residue :: Tuple -> Residue
residue (_,r,_) = r

count :: Tuple -> Count
count (_,_,k) = k

-- P.249
mktuples :: Nat -> [Denom] -> [Tuple]
mktuples n = foldr (concatMap . extend) [([],n,0)]
extend :: Denom -> Tuple -> [Tuple]
extend d (cs,r,k) = [(cs++[c], r-c*d, k+c) | c <- [0..r `div` d]]

-- P.249
-- length (mktuples 256 ukds) == 10640485

-- P.249
-- mkchange :: Nat -> [Denom] -> [Coin]
-- mkchange n <- coins・MinWith cost ・mktuples n
cost :: Tuple -> (Residue, Count)
cost t = (residue t, count t)

-- P.250
(≼) :: Tuple -> Tuple -> Bool
t1 ≼ t2 = (residue t1 == residue t2) && (count t1 <= count t2)

{-
P.250
ThinBy (≼) (step d (ThinBy (≼) ts)) ← ThinBy (≼) (step d ts) (10.1)
where step = concatMap . extend
-}

-- P.251
tstep d = thinBy (≼) . mergeBy cmp . map (extend d)
  where cmp t1 t2 = residue t1 >= residue t2

-- P.263, Answer10.15
mergeBy :: (a -> a -> Bool) -> [[a]] -> [a]
mergeBy cmp = foldr merge [] where
  merge xs [] = xs
  merge [] ys = ys
  merge (x:xs) (y:ys)
    | cmp x y = x : merge xs (y:ys)
    | otherwise = y : merge (x:xs) ys

-- P.251
mkchange :: Nat -> [Denom] -> [Coin]
mkchange n = coins . minWith cost . foldr tstep [([],n,0)]
