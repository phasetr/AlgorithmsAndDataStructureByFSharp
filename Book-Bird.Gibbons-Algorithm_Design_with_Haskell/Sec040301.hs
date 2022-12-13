module Sec040301 where
import Lib (Nat)
-- P.73 4.3 Binary search trees
-- P.73
data Tree a = Null | Node (Tree a) a (Tree a)

-- P.74
size :: Tree a -> Nat
size Null = 0
size (Node l x r) = 1+size l+size r
-- P.74
flatten :: Tree a -> [a]
flatten Null = []
flatten (Node l x r) = flatten l++[x]++flatten r

-- P.74
search :: Ord k => (a -> k) -> k -> Tree a -> Maybe a
search key k Null = Nothing
search key k (Node l x r)
  | key x<k    = search key k r
  | key x == k = Just x
  | key x>k    = search key k l
  | otherwise  = error "undefined"
-- P.75
height :: Tree a -> Nat
height Null = 0
height (Node l x r) = 1 + max (height l) (height r)

-- P.76
mktree :: Ord a => [a] -> Tree a
mktree [] = Null
mktree (x:xs) = Node (mktree ys) x (mktree zs)
  where (ys,zs) = partition (<x) xs
partition :: (a -> Bool) -> [a] -> ([a], [a])
partition p xs = (filter p xs,filter (not . p) xs)
