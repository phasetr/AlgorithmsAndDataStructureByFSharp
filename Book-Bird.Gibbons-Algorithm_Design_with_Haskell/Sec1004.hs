module Sec1004 where
import Lib (Nat)

-- P.253
type Name = String
type Value = Nat
type Weight = Nat
type Item = (Name,Value,Weight)
type Selection = ([Name],Value,Weight)

-- P.253
name :: Item -> Name
name (n,_,_ ) = n
value :: (a,Value,Weight) -> Value
value (_,v,_) = v
weight :: (a,Value,Weight) -> Weight
weight (_,_,w) = w
{-
-- `swag` means money or goods taken by a thief
swag :: Weight -> [Item] -> Selection
swag w ← MaxWith value・filter (within w)・selections
-}

-- P.253
within :: Weight -> Selection -> Bool
within w sn = weight sn <= w

-- P.254, The other way is left as Exercise 10.21.
selections :: [Item] -> [Selection]
selections = foldr (concatMap . extend) [([],0,0)]
  where extend i sn = [sn, add i sn]
add :: Item -> Selection -> Selection
add i (ns,v,w) = (name i:ns, value i+v, weight i+w)

-- P.254
choices :: Weight -> [Item] -> [Selection]
choices w = foldr (concatMap . extend) [([],0,0)]
  where extend i sn = filter (within w) [sn, add i sn]

-- P.254
(≼) :: Selection -> Selection -> Bool
sn1 ≼ sn2 = value sn1 >= value sn2 && weight sn1 <= weight sn2

-- P.254, The details are left as Exercise 10.20.
--swag w = maxWith value . foldr tstep [([],0,0)] where
--  tstep i = thinBy (≼) . concatMap (extend i)
--  extend i sn = filter (within w) [sn, add i sn]

-- P.255
--swag w = maxWith value・foldr tstep [([ ],0,0)]
--  where
--    tstep i = thinBy (≼) . mergeBy cmp・map (extend i)
--    extend i sn = filter (within w) [sn,add i sn]
--    cmp sn1 sn2 = weight sn1 <= weight sn2
