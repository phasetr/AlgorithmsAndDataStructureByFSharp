module Sec1406 where
import Data.Array (array,elems)
import Lib (Nat,single)
import Sec0801 (fringe)
import Sec0802 (depths)
import Sec140101 (Tree(..),Weight)
-- P.349 14.6 The Garsia-Wach algorithm

-- P.349
gwa :: [Weight] -> Tree Weight
gwa ws = rebuild ws (build ws)

-- P.349
type Label = Int
-- P.353
build :: [Weight] -> Tree Label
build ws = extract (foldr step [] (zip (map Leaf [0..]) (infinity:ws))) where
  extract [_,(t,_)] = t
  infinity = sum ws
-- P.351
rebuild :: [Weight] -> Tree Label -> Tree Weight
rebuild ws = reduce . zip (map Leaf ws) . sortDepths
-- P.048
size :: Tree a -> Nat
size (Leaf x) = 1
size (Node _ l x r) = 1+size l+size r
-- P.352
sortDepths :: Tree Label -> [Depth]
sortDepths t = elems (array (1, size t) (zip (fringe t) (depths t)))

-- P.351
type Depth = Int
depth = snd
-- P.351
reduce :: [(Tree Label, Depth)] -> Tree Label
reduce = extract . until single step where
  extract [(t,_)] = t
  step (x:y:xs) = if depth x == depth y then join x y : xs else x : step (y:xs)
  join (t1,d) (t2,_) = (Fork t1 t2, d-1)
-- P.351
reduce2 :: [(Tree Label, Depth)] -> Tree Label
reduce2 = extract . foldl step [] where
  extract [(t,_)] = t
  step [] y = [y]
  step (x:xs) y = if depth x == depth y then step xs (join x y) else y:x:xs
  join(t1,d) (t2,_) = (Fork t1 t2, d-1)

-- P.353
type Pair = (Tree Label,Weight)
weight :: Pair -> Weight
weight (t,w) = w

-- P.354
step :: Pair -> [Pair] -> [Pair]
step x (y:z:xs)
  | weight x < weight z = x:y:z:xs
  | otherwise = step x (insert (join y z) xs)
step x xs = x:xs
join :: Pair -> Pair -> Pair
join (t1,w1) (t2,w2) = (Fork t1 t2,w1 +w2)
insert :: Pair -> [Pair] -> [Pair]
insert x xs = ys++step x zs where
  (ys,zs) = splitList x xs
  splitList x xs = span (\y -> weight y < weight x) xs

-- P.76
node :: List a -> a -> List a -> List a
node l x r = Node h l x r where h = 1 + max (height l) (height r)
-- P.76
height :: List a -> Nat
height Null = 0
height (Node h _ _ _) = h
-- P.78
bias :: List a -> Int
bias (Node _ l x r) = height l - height r
bias _ = error "undefined"
-- P.79
balance :: List a -> a -> List a -> List a
balance t1 x t2
  | abs (h1-h2) <= 1 = node t1 x t2
  | h1 == h2 +2 = rotateR t1 x t2
  | h2 == h1 +2 = rotateL t1 x t2
  | otherwise = error "undefined"
  where h1 = height t1; h2 = height t2
rotateR :: List a -> a -> List a -> List a
rotateR t1 x t2 =
  if 0 <= bias t1 then rotr (node t1 x t2)
  else rotr (node (rotl t1) x t2)
rotateL :: List a -> a -> List a -> List a
rotateL t1 x t2 =
  if bias t2 <= 0 then rotl (node t1 x t2)
  else rotl (node t1 x (rotr t2))
-- P.94
rotr :: List a -> List a
rotr (Node _ (Node _ ll y rl) x r) = node ll y (node rl x r)
rotr _ = error "undefined"
-- P.95
rotl :: List a -> List a
rotl (Node _ ll y (Node _ lrl z rrl)) = node (node ll y lrl) z rrl
rotl _ = error "undefined"
-- P.79
balanceR :: List a -> a -> List a -> List a
balanceR (Node _ l y r) x t2 =
  if height r >= height t2+2
  then balance l y (balanceR r x t2)
  else balance l y (node r x t2)
balanceR _ _ _ = error "undefined"
-- P.91 Answer4.16
balanceL :: List a -> a -> List a -> List a
balanceL t1 x (Node _ l y r) =
  if height l >= height t1 +2
  then balance (balanceL t1 x l) y r
  else balance (node t1 x l) y r
balanceL _ _ _ = error "undefined"
-- P.80
gbalance :: List a -> a -> List a -> List a
gbalance t1 x t2
  | abs (h1-h2) <= 2 = balance t1 x t2
  | h1 > h2+2 = balanceR t1 x t2
  | h1+2 < h2 = balanceL t1 x t2
  | otherwise = error "undefined"
  where h1 = height t1; h2 = height t2

-- P.354
-- P.356
data List a = Null | Node Int (List a) (a,a) (List a)
-- P.356
emptyL :: List a
emptyL = Null
nullL :: List a -> Bool
nullL Null = True
nullL _ = False
consL :: a -> List a -> List a
consL x Null = node Null (x,x) Null
consL x (Node _ t1 (y,z) t2) =
  if nullL t1
  then balance (consL x t1) (x,z) t2
  else balance (consL x t1) (y,z) t2
-- P.357
deconsL :: List a -> (a,List a)
deconsL (Node _ t1 (x,y) t2) =
  if nullL t1 then (y,t2)
  else (z,balance t3 (x,y) t2)
  where (z,t3) = deconsL t1
deconsL _ = error "undefined"  
-- P.357
concatL :: List a -> List a -> List a
concatL t1 Null = t1
concatL Null t2 = t2
concatL t1 t2 = gbalance t1 (x,y) t3 where
  x = lastL t1
  (y,t3) = deconsL t2
-- P.357
lastL :: List a -> a
lastL (Node _ t1 (x,y) t2) = if nullL t2 then y else lastL t2
-- P.357
splitL :: Pair -> List Pair -> (List Pair,List Pair)
splitL x t = sew (pieces x t)
-- P.357
data Piece a = LP (List a) (a,a) | RP (a,a) (List a)
pieces :: Pair -> List Pair -> [Piece Pair]
pieces x t = addPiece t [ ] where
  addPiece Null ps = ps
  addPiece (Node _ t1 (y,z) t2) ps =
    if weight x > max (weight y) (weight z)
    then addPiece t2 (LP t1 (y,z):ps)
    else addPiece t1 (RP (y,z) t2 :ps)
-- P.83
sew :: [Piece a] -> (List a, List a)
sew = foldl step (Null,Null) where
  step (t1,t2) (LP t x) = (gbalance t x t1,t2)
  step (t1,t2) (RP x t) = (t1,gbalance t2 x t)

-- P.355
buildL :: [Weight] -> Tree Label
buildL ws = extractL (foldr stepL emptyL (start ws)) where
  start ws = zip (map Leaf [0..]) (infinity:ws)
  infinity = sum ws
extractL :: List Pair -> Tree Label
extractL xs = t where
  (_,ys) = deconsL xs
  ((t,_),_) = deconsL ys
stepL :: Pair -> List Pair -> List Pair
stepL x xs = if nullL xs || nullL ys || weight x < weight z
  then consL x xs
  else stepL x (insertL (join y z) zs)
  where
    (y,ys) = deconsL xs
    (z,zs) = deconsL ys
insertL :: Pair -> List Pair -> List Pair
insertL x xs = concatL ys (stepL x zs) where
  (ys,zs) = splitL x xs
