module Sec1302 where
import Lib (Nat)
-- P.316
type Name = String
type Value = Nat
type Weight = Nat
type Item = (Name,Value,Weight)
type Selection = ([Name],Value,Weight)
name :: (a, b, c) -> a
name (n,_,_) = n
value :: (a, b, c) -> b
value (_,v,_) = v
weight :: (a, b, c) -> c
weight (_,_,w) = w

{-
P.316
In Section 10.4 we specified swag by
swag::Weight → [Item] → Selection
swag w ← MaxWith value・choices w
-}

-- P.316
choices :: Weight -> [Item] -> [Selection]
choices w [] = [([],0,0)]
choices w (i:is) = if w<wi then choices w is
  else choices w is++map (add i) (choices (w-wi) is)
  where wi = weight i
add :: Item -> Selection -> Selection
add i (ns,v,w) = (name i:ns,value i+v,weight i+w)

-- P.318
swag :: Weight -> [Item] -> Selection
swag w [] = ([],0,0)
swag w (i:is) = if w<wi then swag w is
  else better (swag w is) (add i (swag (w-wi) is))
  where wi = weight i
better :: Selection -> Selection -> Selection
better sn1 sn2 = if value sn1 >= value sn2 then sn1 else sn2

swag2 :: Weight -> [Item] -> Selection
swag2 w = head . foldr step start where
  start = replicate (w+1) ([ ],0,0)
  step i row = zipWith better row (map (add i) (drop wi row))
               ++drop (w+1-wi) row
    where wi = weight i
