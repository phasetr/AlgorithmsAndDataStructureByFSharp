-- P.194, 8.1 Minimum-height trees
module Sec0801 where
import Lib (Nat, wrap, unwrap, single, pairWith)

main :: IO ()
main = do
  print $ (fringe . mktree) [1..3] == [1..3]
  print $ mktree [1..3] == Node (Leaf 1) (Node (Leaf 2) (Leaf 3))
  print $ mktree1 [1..3] == Node (Node (Leaf 1) (Leaf 2)) (Leaf 3)
  -- P.180
  print $ rollup [Leaf 1, Leaf 2, Leaf 3, Leaf 4] == Node (Node (Node (Leaf 1) (Leaf 2)) (Leaf 3)) (Leaf 4)
  -- P.180
  let ts = [Leaf 1, Leaf 2, Leaf 3, Leaf 4]
  print $ (spine . rollup) ts == ts

data Tree a = Leaf a | Node (Tree a) (Tree a) deriving (Show, Eq)

-- P.177
size :: Tree a -> Nat
size (Leaf x) = 1
size (Node u v) = size u + size v

-- P.177
height :: Tree a -> Nat
height (Leaf x) = 0
height (Node u v) = 1 + height u `max` height v

-- P.178, previouly flatten
fringe :: Tree a -> [a]
fringe (Leaf x) = [x]
fringe (Node u v) = fringe u ++ fringe v

-- P.178
mktree :: [a] -> Tree a
mktree [x] = Leaf x
mktree xs = Node (mktree ys) (mktree zs)
  where (ys,zs) = splitAt (length xs `div` 2) xs

-- P.178
mktree1 = unwrap . until single (pairWith Node). map Leaf

-- P.179
cost :: Tree Nat -> Nat
cost (Leaf x) = x
cost (Node u v) = 1 + cost u `max` cost v

-- P.179, P.185
mct :: [Nat] -> Tree Nat
mct = foldrn gstep Leaf

-- P.179
mktrees1 :: [a] -> [Tree a]
mktrees1 [] = error "mktrees1: empty list"
mktrees1 [x] = [Leaf x]
mktrees1 (x:xs) = concatMap (extend x) (mktrees1 xs)

-- P.179
extend :: a -> Tree a -> [Tree a]
extend x (Leaf y) = [Node (Leaf x) (Leaf y)]
extend x (Node u v) = Node (Leaf x) (Node u v) : [Node u' v | u' <- extend x u]

-- P.180
foldrn :: (a -> b -> b)-> (a -> b) -> [a] -> b
foldrn f g [] = error "foldrn: empty list"
foldrn f g [x] = g x
foldrn f g (x:xs) = f x (foldrn f g xs)

-- P.180
mktrees2 :: [a] -> [Tree a]
mktrees2 = foldrn (concatMap . extend) (wrap . Leaf)

-- P.180
type Forest a = [Tree a]

-- P.180
rollup :: Forest a -> Tree a
rollup = foldl1 Node

-- P.180
spine :: Tree a -> Forest a
spine (Leaf x) = [Leaf x]
spine (Node u v) = spine u ++ [v]

-- P.180
mktrees3 :: [a] -> Forest a
mktrees3 = map rollup . mkforests
  where
    -- P.181
    mkforests :: [a] -> [Forest a]
    mkforests = foldrn (concatMap . extend) (wrap . wrap . Leaf)
    extend :: a -> Forest a -> [Forest a]
    extend x ts = [Leaf x : rollup (take k ts) : drop k ts | k <- [1..length ts]]
    -- extend x [t1,t2,t3] = [[Leaf x,t1,t2,t3], [Leaf x,Node t1 t2,t3], [Leaf x,Node (Node t1 t2) t3]]

{-
P.180
foldrn f2 g2 xs ← M (foldrn f1 g1 xs)
g2 x ← M (g1 x)
f2 x (M (foldrn f1 g1 xs)) ← M (f1 x (foldrn f1 g1 xs))
M = MinWith cost
f1 = concatMap・extend
g1 = wrap・leaf

Leaf x = MinWith cost [Leaf x]
g2 = Leaf
gstep x (MinWith cost (mktrees xs))
← MinWith cost (concatMap (extend x) (mktrees xs))
cost t <= cost t' ⇒ cost (gstep x t) <= cost (gstep x t′)
-}

-- P.181
lcost :: Tree Nat -> [Nat]
lcost = reverse . scanl1 op . map cost . spine
  where op x y = 1 + (x `max` y)

-- P.185
gstep :: Nat -> Tree Nat -> Tree Nat
gstep x = rollup . add x . spine

add :: Int -> Forest Nat -> Forest Nat
add x ts = Leaf x : join x ts
  where
    join :: Nat -> Forest Nat -> Forest Nat
    join x [u] = [u]
    join x (u:v:ts) =
      if x `max` cost u < cost v
      then u:v:ts else join x (Node u v : ts)
    join _ _ = error "join: empty list"

{-
P.185
foldrn gstep Leaf = rollup . foldrn hstep g
rollup . g = Leaf
rollup [Leaf x] = Leaf x,
g = wrap・Leaf
rollup (hstep x ts) = gstep x (rollup ts)
-}

-- P.185
mct2 :: [Nat] -> Tree Nat
mct2 = rollup . foldrn add (wrap . Leaf)

-- P.186
type Pair = (Tree Nat, Nat)
mct3 :: [Nat] -> Tree Nat
mct3 = rollup . map fst . foldrn hstep (wrap . leaf)
  where
    hstep :: Nat -> [Pair] -> [Pair]
    hstep x ts = leaf x : join x ts

    join :: Nat -> [Pair] -> [Pair]
    join x [u] = [u]
    join x (u:v:ts) =
      if x `max` snd u < snd v
      then u:v:ts else join x (node u v : ts)
    join _ [] = error "join: empty list"

    leaf :: Nat -> Pair
    leaf x = (Leaf x, x)
    node :: Pair -> Pair -> Pair
    node (u,c) (v,d) = (Node u v, 1 + c `max` d)

-- P.200, Exercise8.6, P.202 Answer8.6
greedy :: [Nat] -> Tree Nat
greedy = rollup . map fst . foldrn insert (wrap . leaf)
  where
    insert :: Nat -> [Pair] -> [Pair]
    insert x ts = leaf x : join ts

    join :: [Pair] -> [(Tree Nat, Nat)]
    join [u] = [u]
    join (u:v:ts) = if snd u < snd v then u:v:ts else join (node u v:ts)
    join _ = error "join: error"

    node :: Pair -> Pair -> Pair
    node (u,c) (v,d) = (Node u v, 1 + c `max` d)

    leaf :: Nat -> Pair
    leaf x = (Leaf x, 0)

-- P.200, Exercise8.7, P.202 Answer8.7
splits [] = [([],[])]
splits (x:xs) = ([],x:xs) : [(x:ys,zs) | (ys,zs) <- splits xs]

splits :: [a] -> [([a],[a])]
splitsn :: [a] -> [([a], [a])]
splitsn [] = []
splitsn [x] = []
splitsn (x:xs) = ([x],xs) : [(x:ys,zs) | (ys,zs) <- splitsn xs]

-- P.200, Exercise8.8, P.202 Answer8.8
mktrees4 :: [a] -> Forest a
mktrees4 [x] = [Leaf x]
mktrees4 xs = [Node u v | (ys,zs) <- splitsn xs,
               u <- mktrees4 ys, v <- mktrees4 zs]
