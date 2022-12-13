module Sec0401 where
import Lib (Nat)
-- P.63 4.1 A one-dimensional search problem
-- P.63
search :: (Nat -> Nat) -> Nat -> [Nat]
search f t = [x | x <- [0..t],t == f x]

-- P.63
search2 :: (Nat -> Nat) -> Nat -> [Nat]
search2 f t = seek (0,t) where
  seek (a,b) = [x | x <- [a..b],t == f x]

-- P.64
search3 :: (Nat -> Nat) -> Nat -> [Nat]
search3 f t = seek (0,t) where
  seek (a,b) | a>b = [ ]
             | t <f m = seek (a,m-1)
             | t == f m = [m]
             | otherwise = seek (m+1,b)
    where
      m = choose (a,b)
      choose (a,b) = (a+b) `div` 2

-- P.65
bound :: (Nat -> Nat) -> Nat -> (Int,Nat)
bound f t = if t <= f 0 then (-1,0) else (b `div` 2,b) where
  b = until done (*2) 1
  done b = t <= f b

-- P.65
search4 :: (Nat -> Nat) -> Nat -> [Nat]
search4 f t = if f x == t then [x] else [] where
  x = smallest (bound f t)
  smallest (a,b) = head [x | x <- [a+1..b], t <= f x]

-- P.65
search5 :: (Nat -> Nat) -> Nat -> [Nat]
search5 f t = if f x == t then [x] else [] where
  x = smallest (bound f t) f t where
    smallest (a,b) f t | a+1 == b = b
                       | t <= f m = smallest (a,m) f t
                       | otherwise = smallest (m,b) f t
      where m = (a+b) `div` 2
