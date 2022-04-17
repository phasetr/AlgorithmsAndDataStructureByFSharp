-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 26 : Combinatorial Algorithms

module Chap26_combinatorial_algorithms where

import Test.QuickCheck (quickCheck, quickCheckWith, stdArgs, maxSize, Property, (==>))

import Data.List (sort)

-- Repetitions in a list

-- ** nub is from Data.List
nub :: Eq a => [a] -> [a]
nub []     = []
nub (x:xs) = x : nub [ y | y <- xs, x /= y ]

distinct :: Eq a => [a] -> Bool
distinct xs = xs == nub xs

b0 = distinct "avocado"

b1 = distinct "peach"

-- Sublists

sub :: Eq a => [a] -> [a] -> Bool
xs `sub` ys = and [ x `elem` ys | x <- xs ]

b2 = "pea" `sub` "apple"

b3 = "peach" `sub` "apple"

subs :: [a] -> [[a]]
subs []     = [[]]
subs (x:xs) = subs xs ++ map (x:) (subs xs)

ls0 = subs [0,1]

ls1 = subs "abc"

subs_prop :: [Int] -> Property
subs_prop xs =
  distinct xs ==>
    and [ ys `sub` xs | ys <- subs xs ]
    && distinct (subs xs)
    && all distinct (subs xs)
    && length (subs xs) == 2 ^ length xs

sizeCheck n = quickCheckWith (stdArgs {maxSize = n})

qc0 = sizeCheck 10 subs_prop

-- Cartesian product

cpair :: [a] -> [b] -> [(a,b)]
cpair xs ys = [ (x,y) | x <- xs, y <- ys ]

cp :: [[a]] -> [[a]]
cp []       = [[]]
cp (xs:xss) = [ y:ys | y <- xs, ys <- cp xss ]

cp_prop :: [[Int]] -> Property
cp_prop xss =
  distinct (concat xss) ==>
    and [ and [ elem (ys !! i) (xss !! i)
                | i <- [0..length xss-1] ]
          | ys <- cp xss ]
    && distinct (cp xss)
    && all distinct (cp xss)
    && all (\ys -> length ys == length xss) (cp xss)
    && length (cp xss) == product (map length xss)

qc1 = quickCheck cp_prop

qc1' = sizeCheck 10 cp_prop

-- Permutations of a list


permscp :: Eq a => [a] -> [[a]]
permscp xs | distinct xs =
  [ ys | ys <- cp (replicate (length xs) xs), distinct ys ]

permscp_prop :: [Int] -> Property
permscp_prop xs =
  distinct xs ==> 
    and [ sort ys == sort xs | ys <- permscp xs ]
    && distinct (permscp xs)
    && all distinct (permscp xs)
    && length (permscp xs) == fac (length xs)

fac :: Int -> Int
fac n | n >= 0 = product [1..n]

qc2 = sizeCheck 10 permscp_prop

splits :: [a] -> [(a, [a])]
splits xs =
  [ (xs!!k, take k xs ++ drop (k+1) xs) | k <- [0..length xs-1] ]

ps0 = splits "abc"

splits_prop :: [Int] -> Property
splits_prop xs =
  distinct xs ==>
    and [ sort (y:ys) == sort xs | (y,ys) <- splits xs ]
    && and [ 1 + length ys == length xs | (y,ys) <- splits xs ]
    && distinct (map snd (splits xs))
    && distinct (map fst (splits xs))
    && all distinct (map snd (splits xs))
    && length (splits xs) == length xs

qc3 = quickCheck splits_prop

perms :: [a] -> [[a]]
perms []     = [[]]
perms (x:xs) = [ y:zs | (y,ys) <- splits (x:xs), zs <- perms ys ]

ls2 = perms "abc"

perms_prop :: [Int] -> Property
perms_prop xs =
  distinct xs ==> 
    and [ sort ys == sort xs | ys <- perms xs ]
    && distinct (perms xs)
    && all distinct (perms xs)
    && length (perms xs) == fac (length xs)

qc4 = sizeCheck 10 perms_prop

perms_permscp_prop :: [Int] -> Property
perms_permscp_prop xs =
  distinct xs ==> perms xs == permscp xs

qc5 = sizeCheck 10 perms_permscp_prop

-- Choosing k elements from a list

choose :: Int -> [a] -> [[a]]
choose 0 xs             = [[]]
choose k []     | k > 0 = []
choose k (x:xs) | k > 0 =
  choose k xs ++ map (x:) (choose (k-1) xs)

ls3 = choose 3 "abcde"

choose_prop :: Int -> [Int] -> Property
choose_prop k xs =
  0 <= k && k <= n && distinct xs ==>
    and [ ys `sub` xs && length ys == k | ys <- choose k xs ]
    && distinct (choose k xs)
    && all distinct (choose k xs)
    && length (choose k xs) == fac n `div` (fac k * fac (n-k))
      where n = length xs

choose_length_prop :: [Int] -> Bool
choose_length_prop xs =
  sum [ length (choose k xs) | k <- [0..n] ] == 2^n
    where n = length xs

choose_subs_prop :: [Int] -> Bool
choose_subs_prop xs =
  sort [ ys | k <- [0..n], ys <- choose k xs ] == sort (subs xs)
    where n = length xs

qc6 = sizeCheck 10 choose_prop

qc6' = sizeCheck 10 choose_length_prop

qc6'' = sizeCheck 10 choose_subs_prop

-- Partitions of a number

partitions :: Int -> [[Int]]
partitions 0 = [[]]
partitions n | n > 0
  = [ k : xs | k <- [1..n], xs <- partitions (n-k), all (k <=) xs ]

ls4 = partitions 5

partitions_prop :: Int -> Property
partitions_prop n  =
  n >= 0 ==> all ((== n) . sum) (partitions n)
  
partitions_prop' :: [Int] -> Property
partitions_prop' xs =
  all (> 0) xs ==> sort xs `elem` partitions (sum xs)

qc7 = sizeCheck 10 partitions_prop

qc7' = sizeCheck 8 partitions_prop'

-- Making change

type Coin = Int
type Total = Int

change :: Total -> [Coin] -> [[Coin]]
change n xs = change' n (sort xs)
  where change' 0 xs         = [[]]
        change' n xs | n > 0 =
          [ y : zs | (y, ys) <- nub (splits xs),
                     y <= n,
                     zs <- change' (n-y) (filter (y <=) ys) ]

ls5 = change 30 [5,5,10,10,20]

change_prop :: Total -> [Coin] -> Property
change_prop n xs =
  0 <= n && all (0 <) xs ==>
    all ((== n) . sum) (change n xs)

qc8 = sizeCheck 10 change_prop

-- Eight queens problem

type Row   = Int
type Col   = Int
type Coord = (Col, Row)
type Board = [Row]

queens :: Col -> [Board]
queens 0         = [[]]
queens n | n > 0 =
  [ q:qs | q <- [1..8],
           qs <- queens (n-1),
           and [ not (attack (1,q) (x,y))
               | (x,y) <- zip [2..n] qs ] ]

attack :: Coord -> Coord -> Bool
attack (x,y) (x',y') =
  x == x'         -- both in the same column
  || y == y'      -- both in the same row
  || x+y == x'+y' -- both on the line y = -x + b
  || x-y == x'-y' -- both on the line y = x + b

q8 = head (queens 8)

i0 = length (queens 8)

queens' :: [Board]
queens' = filter ok (perms [1..8])

ok :: Board -> Bool
ok qs = and [ not (attack' p p') | [p,p'] <- choose 2 (coords qs) ]

coords :: Board -> [Coord]
coords qs = zip [1..] qs
                 
attack' :: Coord -> Coord -> Bool
attack' (x,y) (x',y') = abs (x-x') == abs (y-y')

q8' = head queens'

i0' = length queens'

-- Exercise 7

fib :: Int -> Int
fib 0 = 0
fib 1 = 1
fib n = fib (n-1) + fib (n-2)

fiblist :: [Int]
fiblist = map fib' [0..]

fib' :: Int -> Int
fib' 0 = 0
fib' 1 = 1
fib' n = fiblist!!(n-1) + fiblist!!(n-2)
