-- P.47, 3.2 Random-access lists
module Sec0302 where
import Data.List
import Lib (Nat, single)

-- P.47
fetch :: Nat -> [a] -> a
fetch k xs = if k==0 then head xs else fetch (k-1) (tail xs)

{-
-- P.047
data Tree a = Leaf a | Node (Tree a) (Tree a)
-- P.047
size (Leaf x) = 1
size (Node t1 t2) = size t1 + size t2
-}

-- P.048
data Tree a = Leaf a | Node Nat (Tree a) (Tree a)
size :: Tree a -> Nat
size (Leaf x) = 1
size (Node n _ _) = n

-- P.048
node :: Tree a -> Tree a -> Tree a
node t1 t2 = Node (size t1 + size t2) t1 t2

-- P.049
data Digit a = Zero | One (Tree a)
type RAList a = [Digit a]

-- P.049
fromRA :: RAList a -> [a]
fromRA = concatMap from
  where
    from Zero = []
    from (One t) = fromT t
-- P.049
fromT :: Tree a -> [a]
fromT (Leaf x) = [x]
fromT (Node _ t1 t2) = fromT t1 ++ fromT t2

-- P.049, P.054 Exercise3.9, P.057, Answer3.9
fetchRA :: Nat -> RAList a -> a
fetchRA k (Zero:xs) = fetchRA k xs
fetchRA k (One t:xs) =
  if k < size t then fetchT k t else fetchRA (k - size t)xs
fetchRA k [] = error "index too large"
-- P.049
fetchT :: Nat -> Tree a -> a
fetchT 0 (Leaf x) = x
fetchT k (Node n t1 t2) =
  if k<m then fetchT k t1 else fetchT (k-m) t2
  where m = n `div` 2
fetchT _ _ = error "fetchT: error"

-- P.050
nullRA :: RAList a -> Bool
nullRA = null
-- P.050
nilRA :: RAList a
nilRA = []
-- P.050
consRA :: a -> RAList a -> RAList a
consRA x = consT (Leaf x)
consT t1 [] = [One t1]
consT t1 (Zero : xs) = One t1 : xs
consT t1 (One t2:xs) = Zero : consT (node t1 t2) xs
-- P.050
inc [] = [1]
inc (0:bs) = 1:bs
inc (1:bs) = 0:inc bs
inc _ = error "inc: erro"
-- P.050
unconsRA :: RAList a -> (a,RAList a)
unconsRA xs = (x,ys) where (Leaf x, ys) = unconsT xs
unconsT :: RAList a -> (Tree a, RAList a)
unconsT (One t:xs) = if null xs then (t,[]) else (t, Zero:xs)
unconsT (Zero:xs) = (t1, One t2:xs)
  where (Node _ t1 t2, ys) = unconsT xs
unconsT _ = error "unconsT: error"
-- P.050
dec [1] = []
dec (1:ds) = 0:ds
dec (0:ds) = 1 : dec ds
dec _ = error "dec: error"
-- P.050, P.055 Exercise3.11, P.057 Answer3.11
updateRA :: Nat -> a -> RAList a -> RAList a
updateRA k x (Zero:xs) = Zero : updateRA k x xs
updateRA k x (One t :xs) = if k < size t
  then One (updateT k x t):xs
  else One t :updateRA (k - size t) x xs
updateRA _ _ _ = error "updateRA: error"
updateT :: Nat -> a -> Tree a -> Tree a
updateT 0 x (Leaf y) = Leaf x
updateT k x (Node n t1 t2) =
  if k<m then Node n (updateT k x t1) t2
  else Node n t1 (updateT (k-m) x t2)
  where m = n `div` 2
updateT _ _ _ = error "updateT: error"

-- P.055 Exercise3.10, P.057, Answer3.10
toRA :: [a] -> RAList a
toRA = foldr consRA nilRA

-- P.055 Exercise3.12, P.058 Answer3.12
(//) :: RAList a -> [(Nat,a)] -> RAList a
(//) = foldl (flip (uncurry updateRA))

-- P.058, Answer3.13
headRA xs = fst (unconsRA xs)
tailRA xs = snd (unconsRA xs)

-- cf. https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:lookup
lookupRA :: Int -> RAList a -> Digit a
lookupRA k xs = xs !! k
