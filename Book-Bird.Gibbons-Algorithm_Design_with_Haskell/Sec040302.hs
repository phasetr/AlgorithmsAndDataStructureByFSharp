module Sec040302 where
import Lib (Nat)
-- P.76
data Tree a = Null | Node Nat (Tree a) a (Tree a)

-- P.76
height :: Tree a -> Nat
height Null = 0
height (Node h _ _ _) = h

-- P.76
node :: Tree a -> a -> Tree a -> Tree a
node l x r = Node h l x r where h = 1 + max (height l) (height r)

-- P.76
mktree :: Ord a => [a] -> Tree a
mktree = foldr insert Null
insert :: Ord a => a -> Tree a -> Tree a
insert x Null = node Null x Null
insert x (Node h l y r)
  | x<y = balance (insert x l) y r
  | x == y = Node h l y r
  | y<x = balance l y (insert x r)
  | otherwise = error "undefined"

-- P.78
bias :: Tree a -> Int
bias (Node _ l x r) = height l - height r
bias _ = error "undefined"
-- P.79
balance :: Tree a -> a -> Tree a -> Tree a
balance t1 x t2
  | abs (h1-h2) <= 1 = node t1 x t2
  | h1 == h2 +2 = rotateR t1 x t2
  | h2 == h1 +2 = rotateL t1 x t2
  | otherwise = error "undefined"
  where h1 = height t1; h2 = height t2
rotateR :: Tree a -> a -> Tree a -> Tree a
rotateR t1 x t2 =
  if 0 <= bias t1 then rotr (node t1 x t2)
  else rotr (node (rotl t1) x t2)
rotateL :: Tree a -> a -> Tree a -> Tree a
rotateL t1 x t2 =
  if bias t2 <= 0 then rotl (node t1 x t2)
  else rotl (node t1 x (rotr t2))
-- P.94
rotr :: Tree a -> Tree a
rotr (Node _ (Node _ ll y rl) x r) = node ll y (node rl x r)
rotr _ = error "undefined"
-- P.95
rotl :: Tree a -> Tree a
rotl (Node _ ll y (Node _ lrl z rrl)) = node (node ll y lrl) z rrl
rotl _ = error "undefined"

-- P.81
type Set a = Tree a
-- P.79
balanceR :: Set a -> a -> Set a -> Set a
balanceR (Node _ l y r) x t2 =
  if height r >= height t2+2
  then balance l y (balanceR r x t2)
  else balance l y (node r x t2)
balanceR _ _ _ = error "undefined"
-- P.91 Answer4.16
balanceL :: Set a -> a -> Set a -> Set a
balanceL t1 x (Node _ l y r) =
  if height l >= height t1 +2
  then balance (balanceL t1 x l) y r
  else balance (node t1 x l) y r
balanceL _ _ _ = error "undefined"
-- P.80
gbalance :: Set a -> a -> Set a -> Set a
gbalance t1 x t2
  | abs (h1-h2) <= 2 = balance t1 x t2
  | h1 > h2+2 = balanceR t1 x t2
  | h1+2 < h2 = balanceL t1 x t2
  | otherwise = error "undefined"
  where h1 = height t1; h2 = height t2

-- P.74
flatten :: Tree a -> [a]
flatten Null = []
flatten (Node _ l x r) = flatten l++[x]++flatten r
-- P.80
sort :: (Ord a) => [a] -> [a]
sort = flatten . mktree
