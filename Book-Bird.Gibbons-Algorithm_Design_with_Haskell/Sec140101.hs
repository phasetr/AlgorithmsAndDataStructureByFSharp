module Sec140101 where
import Lib (Nat,minWith)
import Sec0801 (splitsn)
-- P.336, 14.1 A cubic-time algorithm
-- P.336
data Tree a = Leaf a | Fork (Tree a) (Tree a)

{-
P.336
mct ::[Weight] → Tree Weight
mct ← MinWith cost ・mktrees
-}

-- P.336
mktrees :: [a] -> [Tree a]
mktrees [w] = [Leaf w]
mktrees ws = [Fork t1 t2
             | (us,vs) <- splitsn ws,
               t1 <- mktrees us, t2 <- mktrees vs]

-- P.337
type Cost = Nat
cost :: Tree Weight -> Cost
cost (Leaf w) = 0
cost (Fork t1 t2) = cost t1 + cost t2 + f (weight t1) (weight t2)

weight :: Tree Weight -> Weight
weight (Leaf w) = w
weight (Fork t1 t2) = g (weight t1) (weight t2)

-- P.337
type Weight = (Nat,Nat)
f :: Weight -> Weight -> Cost
f (p,q) (q',r) | q==q' = p*q*r
f _ _ = error "undefined"
g :: Weight -> Weight -> Weight
g (p,q) (q',r) | q==q' = (p,r)
g _ _ = error "undefined"

-- P.337
mct :: [Weight] -> Tree Weight
mct [w] = Leaf w
mct ws = minWith cost [Fork (mct us) (mct vs) | (us,vs) <- splitsn ws]
