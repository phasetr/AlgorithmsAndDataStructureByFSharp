-- Chapter 03 Useful data structures
module Chap03 where
import           Data.Array                     ( Ix(range)
                                                , accum
                                                , accumArray
                                                , array
                                                , assocs
                                                )

type Nat = Int
type SymList a = ([a], [a])

single :: [a] -> Bool
single [x] = True
single _   = False

-- Answer 3.2
nilSL :: SymList a
nilSL = ([], [])

nullSL :: SymList a -> Bool
nullSL (xs, ys) = null xs && null ys

singleSL :: SymList a -> Bool
singleSL (xs, ys) = (null xs && single ys) || (null ys && single xs)

lengthSL :: SymList a -> Nat
lengthSL (xs, ys) = length xs + length ys

fromSL :: SymList a -> [a]
fromSL (xs, ys) = xs ++ reverse ys

-- invariants
-- single: singleton check
-- null xs => null ys || single ys
-- null ys => null xs || single xs

snocSL :: a -> SymList a -> SymList a
snocSL x (xs, ys) = if null xs then (ys, [x]) else (xs, x : ys)

lastSL :: SymList a -> a
lastSL (xs, ys) = if null xs then head xs else head ys

-- Answer 3.3
consSL :: a -> SymList a -> SymList a
consSL x (xs, ys) = if null ys then ([x], xs) else (x : xs, ys)

headSL :: SymList a -> a
headSL (xs, ys) = if null xs then head ys else head xs

tailSL :: SymList a -> SymList a
tailSL (xs, ys) | null xs   = if null ys then undefined else nilSL
                | single xs = (reverse vs, us)
                | otherwise = (tail xs, ys)
  where (us, vs) = splitAt (length ys `div` 2) ys

-- Prelude.init [1,2,3,4]
-- Prelude.tail [1,2,3,4]
-- Answer 3.4 先取り
initSL :: SymList a -> SymList a
initSL (xs, ys) | null xs   = if null ys then undefined else nilSL
                | single ys = (us, reverse vs)
                | otherwise = (xs, tail ys)
  where (us, vs) = splitAt (length xs `div` 2) xs
-- initSL ([1,2], [4,3])

-- Chap02 参照
-- 線型時間で length . inits を計算できる
-- 要素全部を出力するのに n^2 かかるのは変わらない
-- Answer 3.7
inits :: [a] -> [[a]]
inits = map fromSL . scanl (flip snocSL) nilSL
-- 5001 == (Prelude.length $ Chap01.inits [1..5000])
-- 50000 == (Prelude.length $ Chap03.inits [1..50000])

-- P.47 大事な注意
-- ここで議論した内容・関数は Data.Sequence に実装されていて、
-- 二重リストではない 2-3 finger tree というデータ構造を使っている。

-- P.47 3.2 Random-access lists
fetch :: Nat -> [a] -> a
fetch k xs = if k == 0 then head xs else fetch (k - 1) (tail xs)

data Tree a = Leaf a | Node Nat (Tree a) (Tree a)
  deriving Show

size :: Tree a -> Nat
size (Leaf x    ) = 1
size (Node n _ _) = n

node :: Tree a -> Tree a -> Tree a
node t1 t2 = Node (size t1 + size t2) t1 t2

-- print $ Node 4 (Node 2 (Leaf 'a') (Leaf 'b')) (Node 2 (Leaf 'c') (Leaf 'd'))

data Digit a = Zero | One (Tree a) deriving Show
type RAList a = [Digit a]
-- [Zero,One (Node 2 (Leaf 'a') (Leaf 'b')),One (Node 4 (Node 2 (Leaf 'c') (Leaf 'd')) (Node 2 (Leaf 'e') (Leaf 'f')))]
-- [One (Leaf 'a'), Zero, One (Node 4 (Node 2 (Leaf 'b') (Leaf 'c')) (Node 2 (Leaf 'd') (Leaf 'e')))]

-- In Exercise we will make a more efficient function.
fromRA :: RAList a -> [a]
fromRA = concatMap from
 where
  from Zero    = []
  from (One t) = fromT t

  fromT :: Tree a -> [a]
  fromT (Leaf x      ) = [x]
  fromT (Node _ t1 t2) = fromT t1 ++ fromT t2

-- Answer 3.9
fetchRA :: Nat -> RAList a -> a
fetchRA k (Zero : xs) = fetchRA k xs
fetchRA k (One t : xs) =
  if k < size t then fetchT k t else fetchRA (k - size t) xs
fetchRA k [] = error "index too large"
--fetchRA _ [] = error "should not come here"

fetchT :: Nat -> Tree a -> a
fetchT 0 (Leaf x      ) = x
fetchT k (Node n t1 t2) = if k < m then fetchT k t1 else fetchT (k - m) t2
  where m = n `div` 2
fetchT _ _ = error "should not come here"

nullRA :: RAList a -> Bool
nullRA = null

nilRA :: RAList a
nilRA = []

consRA :: a -> RAList a -> RAList a
consRA x = consT (Leaf x)
consT t1 []            = [One t1]
consT t1 (Zero   : xs) = One t1 : xs
consT t1 (One t2 : xs) = Zero : consT (node t1 t2) xs

unconsRA :: RAList a -> (a, RAList a)
unconsRA xs = (x, ys) where (Leaf x, ys) = unconsT xs
unconsT :: RAList a -> (Tree a, RAList a)
unconsT (One t : xs) = if null xs then (t, []) else (t, Zero : xs)
unconsT (Zero  : xs) = (t1, One t2 : ys) where (Node _ t1 t2, ys) = unconsT xs
unconsT _            = error "should not come here"

-- Answer 3.11 先取
updateRA :: Nat -> a -> RAList a -> RAList a
updateRA k x (Zero  : xs) = Zero : updateRA k x xs
updateRA k x (One t : xs) = if k < size t
  then One (updateT k x t) : xs
  else One t : updateRA (k - size t) x xs
updateRA _ _ _ = error "should not come here"

updateT :: Nat -> a -> Tree a -> Tree a
updateT 0 x (Leaf y      ) = Leaf x
updateT k x (Node n t1 t2) = if k < m
  then Node n (updateT k x t1) t2
  else Node n t1 (updateT (k - m) x t2)
  where m = n `div` 2
updateT _ _ _ = error "should not come here"

-- P.51 3.3 Arrays
-- array :: Ix i => (i,i) -> [(i,e)] -> Array i e
-- listArray :: Ix i => (i,i) -> [e] -> Array i e

-- listArray (0,9) [0,1,2,3,4,5,6,7,8,9]
-- accumArray (+) 0 (1,3) [(1,20),(2,30),(1,40),(2,50)] == array (1,3) [(1,60),(2,80),(3,0)]
-- accumArray (Prelude.flip (:)) [ ] ('A','C') [('A',"Apple"),('A',"Apricot")] == array ('A','C') [('A',["Apricot","Apple"]),('B',[ ]),('C',[ ])]
sort :: Nat -> [Nat] -> [Nat]
sort m xs = concatMap copy (assocs a)
 where
  a = accumArray (+) 0 (0, m) (zip xs (repeat 1))
  copy (x, k) = replicate k x
-- sort 3 [3,2,1]

-- Answer 3.1
-- foldl (flip snocSL) nilSL "abcd" == ("a", "dcb")
-- foldr consSL nilSL "abcd" == ("abc", "d")
-- consSL 'a' (snocSL 'd' (foldr consSL nilSL "bc")) == ("ab", "dc")

-- Answer 3.5
dropWhileSL p xs | nullSL xs     = nilSL
                 | p (headSL xs) = dropWhileSL p (tailSL xs)
                 | otherwise     = xs

-- Answer 3.6
initsSL :: SymList a -> SymList (SymList a)
initsSL xs =
  if nullSL xs then snocSL xs nilSL else snocSL xs (initsSL (initSL xs))

-- initsSL ([1,2],[4,3])
-- inits . fromSL == map fromSL . (fromSL . initSL)
-- (Chap03.inits $ fromSL ([1,2],[4,3])) == (map fromSL $ fromSL $ initsSL ([1,2],[4,3]))

-- Answer 3.7
inits' = map reverse . scanl (flip (:)) []
-- inits' [1,2,3,4]
-- scanl (flip (:)) [] [1,2,3,4]

-- Answer 3.8
fromT t = fromTs [t]
fromTs []                  = []
fromTs (Leaf x       : ts) = x : fromTs ts
fromTs (Node _ t1 t2 : ts) = fromTs (t1 : t2 : ts)

-- Answer 3.9: 上にある

-- Answer 3.10
toRA :: [a] -> RAList a
toRA = foldr consRA nilRA
-- toRA [1,2,3,4]

-- Answer 3.11
-- 上にある

-- Answer 3.12
(//) :: RAList a -> [(Nat, a)] -> RAList a
(//) = foldl (flip (uncurry updateRA))
-- toRA [0..3]
-- fromRA $ toRA [0..3]

-- Answer 3.13
headRA :: RAList a -> a
headRA xs = fst $ unconsRA xs
tailRA :: RAList a -> RAList a
tailRA xs = snd $ unconsRA xs
-- headRA $ toRA [0..3]
-- tailRA $ toRA [0..3]

-- Answer 3.14
-- foldl (*) 1 [1..10]
-- scanl (*) 1 [1..10]
-- scanr (*) 1 [1..10]
-- print $ listArray (0,10) (scanl (*) 1 [1..10])
-- fa = listArray (0,10) (1:[i * fa!(i-1) | i <- [1..10]])
-- print fa

-- Answer 3.15
-- array (1,3) [(1,60),(2,80),(3,0)]
-- accumArray (+) 0 (1,3) [(1,20),(2,30),(1,40),(2,50)] == array (1,3) [(1,60),(2,80),(3,0)]
myAccumArray f e bnds = accum f (array bnds [ (i, e) | i <- range bnds ])
  -- myAccumArray (+) 0 (1,3) [(1,20),(2,30),(1,40),(2,50)] == array (1,3) [(1,60),(2,80),(3,0)]
