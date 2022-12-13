-- Chap 04 Binary search
module Chap04 where
type Nat = Int

search :: (Nat -> Nat) -> Nat -> [Nat]
search f t = [ x | x <- [0 .. t], t == f x ]
-- search (*2) 10

search' :: (Nat -> Nat) -> Nat -> [Nat]
search' f t = seek (0, t) where seek (a, b) = [ x | x <- [a .. b], t == f x ]

search'' :: (Nat -> Nat) -> Nat -> [Nat]
search'' f t = seek (0, t)
 where
  seek (a, b) | a > b     = []
              | t < f m   = seek (a, m - 1)
              | t == f m  = [m]
              | otherwise = seek (m + 1, b)
   where
    m = choose (a, b)
    choose (a, b) = (a + b) `div` 2

bound :: (Nat -> Nat) -> Nat -> (Int, Nat)
bound f t = if t <= f 0 then (-1, 0) else (b `div` 2, b)
 where
  b = until done (* 2) 1
  done b = t <= f b

search''' :: (Nat -> Nat) -> Nat -> [Nat]
search''' f t = [ x | f x == t ]
 where
  x = smallest (bound f t)
  smallest (a, b) = head [ x | x <- [a + 1 .. b], t <= f x ]
    --smallest (a,b) =
    --  head [x | x <- [a+1..m], t <= f x] ++ [x | x <- [m+1..b], t <= f x]

-- 2nd binary search
search'''' :: (Nat -> Nat) -> Nat -> [Nat]
search'''' f t = [ x | f x == t ]
 where
  x = smallest (bound f t) f t
  smallest (a, b) f t | a + 1 == b = b
                      | t <= f m   = smallest (a, b) f t
                      | otherwise  = smallest (m, b) f t
    where m = (a + b) `div` 2

-- P.68, 4.2 A two-dimensional search problem
searchP067 :: (Nat -> Nat -> Nat) -> Nat -> [(Nat, Nat)]
searchP067 f t = [ (x, y) | x <- [0 .. t], y <- [0 .. t], t == f x y ]

searchP0681 :: (Nat -> Nat -> Nat) -> Nat -> [(Nat, Nat)]
searchP0681 f t = [ (x, y) | x <- [0 .. t], y <- [t, t - 1 .. 0], t == f x y ]

searchIn :: (Nat, Nat) -> ((Nat, Nat) -> Nat) -> Nat -> [(Nat, Nat)]
searchIn (a, b) f t =
  [ (x, y) | x <- [a .. t], y <- [b, b - 1 .. 0], t == f (x, y) ]

-- saddleback search
searchP0682 :: (Ord a, Num a) => ((a, a) -> a) -> a -> [(a, a)]
searchP0682 f t = searchIn (0, t)
 where
  searchIn (x, y) | x > t || y <= 0 = []
                  | z < t           = (x, y) : searchIn (x + 1, y)
                  | z == t          = (x, y) : searchIn (x + 1, y - 1)
                  | z > t           = searchIn (x, y - 1)
                  | otherwise       = error "should not come here"
    where z = f (x, y)

searchP072 f t = from (0, p) (q, 0)
 where
  smallest (a, b) f t | a + 1 == b = b
                      | t <= f m   = smallest (a, b) f t
                      | otherwise  = smallest (m, b) f t
    where m = (a + b) `div` 2
  p = smallest (-1, t) (\y -> f (0, y)) t
  q = smallest (-1, t) (\x -> f (x, 0)) t
  from (x1, y1) (x2, y2) | x2 < x1 || y1 < y2 = []
                         | y1 - y2 <= x2 - x1 = row x
                         | otherwise          = col y
   where
    x = smallest (x1 - 1, x2) (\x -> f (x, r)) t
    y = smallest (y2 - 1, y2) (\y -> f (c, y)) t
    c = (x1 + x2) `div` 2
    r = (y1 + y2) `div` 2
    row x
      | z < t = from (x1, y1) (x2, r + 1)
      | z == t = (x, r) : from (x1, y1) (x - 1, r + 1) ++ from (x + 1, r - 1)
                                                               (x2   , y2)
      | z > t = from (x1, y1) (x - 1, r + 1) ++ from (x, r - 1) (x2, y2)
      | otherwise = error "should not come here"
      where z = f (x, r)
    col y
      | z < t = from (c + 1, y1) (x2, y2)
      | z == t = (c, y) : from (x1, y1) (c - 1, y + 1) ++ from (c + 1, y - 1)
                                                               (x2   , y2)
      | z > t = from (x1, y1) (c - 1, y) ++ from (c + 1, y - 1) (x2, y2)
      | otherwise = error "should not come here"
      where z = f (c, y)
