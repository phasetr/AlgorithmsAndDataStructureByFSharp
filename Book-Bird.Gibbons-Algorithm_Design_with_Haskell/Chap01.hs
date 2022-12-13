{-# LANGUAGE FlexibleContexts #-}
module Chap01 where
import           Data.List                      ( )
import           Prelude                 hiding ( concatMap
                                                , filter
                                                , flip
                                                , foldl
                                                , foldr
                                                , head
                                                , init
                                                , last
                                                , length
                                                , map
                                                , reverse
                                                , scanl
                                                , until
                                                )

-- 1.1 Basic types and functions
type Nat = Int

{-# ANN map "HLint: ignore" #-}
map :: (a -> b) -> [a] -> [b]
map f []       = []
map f (x : xs) = f x : map f xs

filter :: (a -> Bool) -> [a] -> [a]
filter p []       = []
filter p (x : xs) = if p x then x : filter p xs else filter p xs

{-# ANN foldr "HLint: ignore" #-}
foldr :: (a -> b -> b) -> b -> [a] -> b
foldr f e []       = e
foldr f e (x : xs) = f x (foldr f e xs)

label :: [a] -> [(Nat, a)]
label = zip [0 ..]
-- label xs = zip [0..] xs

length :: [a] -> Nat
length = foldr succ 0 where succ x n = n + 1

foldl :: (c -> b -> c) -> c -> [b] -> c
foldl f e = foldr (flip f) e . reverse

flip :: (a -> b -> c) -> b -> a -> c
flip f x y = f y x

-- 1.2 Processing lists
head :: [a] -> a
head = foldr (<<) undefined where x << y = x

-- Prelude.head [1,2] == 1
-- Chap01.head [1,2] == 1

concat1 :: [[a]] -> [a]
concat1 = foldr (++) []
concat2 :: [[a]] -> [a]
concat2 = foldl (++) []

scanl :: (b -> a -> b) -> b -> [a] -> [b]
scanl f e []       = [e]
scanl f e (x : xs) = e : scanl f (f e x) xs

inserts :: a -> [a] -> [[a]]
inserts x []       = [[x]]
inserts x (y : ys) = (x : y : ys) : map (y :) (inserts x ys)
-- Chap01.inserts 1 [2, 3]

-- 1.3 Inductive and recursive definitions
perms1 :: [a] -> [[a]]
perms1 []       = [[]]
perms1 (x : xs) = [ zs | ys <- perms1 xs, zs <- inserts x ys ]
-- Chap01.perms1 [1, 2, 3]

perms1' :: [a] -> [[a]]
perms1' = foldr step [[]] where step x xss = concatMap (inserts x) xss

concatMap :: (a -> [b]) -> [a] -> [b]
concatMap f = concat1 . map f

perms1'' :: [a] -> [[a]]
perms1'' = foldr (concatMap . inserts) [[]]

picks :: [a] -> [(a, [a])]
picks []       = []
picks (x : xs) = (x, xs) : [ (y, x : ys) | (y, ys) <- picks xs ]

perms2 :: [a] -> [[a]]
perms2 [] = [[]]
perms2 xs = [ x : zs | (x, ys) <- picks xs, zs <- perms2 ys ]

perms2' :: [a] -> [[a]]
perms2' [] = [[]]
perms2' xs = concatMap subperms (picks xs)
  where subperms (x, ys) = map (x :) (perms2 ys)

until :: (a -> Bool) -> (a -> a) -> a -> a
until p f x = if p x then x else until p f (f x)

while :: (a -> Bool) -> (a -> a) -> a -> a
while p = until (not . p)

-- 1.4 Fusion

-- 1.5 Accumulating and tupling
collapse :: [[Int]] -> [Int]
collapse xss = help [] xss
 where
  help xs xss =
    if sum xs > 0 || null xss then xs else help (xs ++ head xss) (tail xss)
-- Chap01.collapse [[-5,3], [-2], [-4], [-4, 1]]

collapse' :: (Ord a, Num a) => [[a]] -> [a]
collapse' xss = help (0, []) (labelsum xss)
 where
  labelsum xss = zip (map sum xss) xss
  help (s, xs) xss = if s > 0 || null xss
    then xs
    else help (cat (s, xs) (head xss)) (tail xss)
    where cat (s, xs) (t, ys) = (s + t, xs ++ ys)

collapse'' :: (Ord a, Num a) => [[a]] -> [a]
collapse'' xss = help (0, id) (labelsum xss) []
 where
  labelsum xss = zip (map sum xss) xss
  help (s, f) xss = if s > 0 || null xss
    then f
    else help (s + t, f . (xs ++)) (tail xss)
    where (t, xs) = head xss

uncons :: [a] -> Maybe (a, [a])
uncons []       = Nothing
uncons (x : xs) = Just (x, xs)

wrap :: a -> [a]
wrap x = [x]

unwrap :: [a] -> a
unwrap [x] = x
unwrap _   = error "should not come here"

single :: [a] -> Bool
single [x] = True
single _   = False

reverse :: [a] -> [a]
reverse = foldl (flip (:)) []

map' :: (t -> a) -> [t] -> [a]
map' f = foldr op [] where op x xs = f x : xs

filter' :: (a -> Bool) -> [a] -> [a]
filter' p = foldr op [] where op x xs = if p x then x : xs else xs

takeWhile :: (a -> Bool) -> [a] -> [a]
takeWhile p = foldr op [] where op x xs = if p x then x : xs else []

dropWhileEnd :: (a -> Bool) -> [a] -> [a]
dropWhileEnd p = foldr op []
  where op x xs = if p x && null xs then [] else x : xs

last :: [a] -> a
last [x     ] = x
last (_ : xs) = last xs
last []       = error "Empty list"

init :: [a] -> [a]
init [x     ] = []
init (x : xs) = x : init xs
init []       = error "Empty list"

-- Answer 1.11
integer :: [Integer] -> Integer
integer = foldl shiftl 0 where shiftl n d = 10 * n + d
fraction :: [Integer] -> Double
fraction = foldr shiftr 0 where shiftr d x = (fromIntegral d + x) / 10

-- Answer 1.12
inits :: [a] -> [[a]]
inits []       = [[]]
inits (x : xs) = [] : map (x :) (inits xs)
myscanl :: (a -> b -> a) -> a -> [b] -> [a]
myscanl f e = map (foldl f e) . inits
-- Chap01.myscanl (*) 1 [1, 2, 3]

tails :: [a] -> [[a]]
tails []       = [[]]
tails (x : xs) = (x : xs) : tails xs
myscanr :: (a -> b -> b) -> b -> [a] -> [b]
myscanr f e = map (foldr f e) . tails

-- Answer 1.13
apply' :: (Eq t, Num t) => t -> (b -> b) -> b -> b
apply' 0 _ = id
apply' n f = f . apply' (n - 1) f

apply'' :: (Eq t, Num t) => t -> (b -> b) -> b -> b
apply'' 0 _ = id
apply'' n f = apply'' (n - 1) f . f

-- P.22, Answer 1.14
