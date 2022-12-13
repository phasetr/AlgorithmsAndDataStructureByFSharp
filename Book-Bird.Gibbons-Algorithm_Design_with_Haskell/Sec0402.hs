module Sec0402 where

-- P.67 4.2 A two-dimensional search problem
search :: (Num b, Enum b, Eq b) => ((b, b) -> b) -> b -> [(b, b)]
search f t = [(x,y) | x <- [0..t], y <- [0..t],t == f(x,y)]

-- P.68
search2 :: (Ord a, Num a) => ((a, a) -> a) -> a -> [(a, a)]
search2 f t = searchIn (0,t) where
  searchIn (x,y)
    | x>t || y<0 = []
    | z<t = searchIn (x+1,y)
    | z == t = (x,y):searchIn (x+1,y-1)
    | z>t = searchIn (x,y-1)
    | otherwise = error "undefined"
    where z = f(x,y)

-- P.72
search3 f t = from (0,p) (q,0) where
  p = smallest (-1,t) (λy.f(0,y)) t
  q = smallest (-1,t) (λx.f(x,0)) t
  from (x1,y1) (x2,y2)
    | x2 < x1 || y1 < y2 = []
    | y1-y2 <= x2-x1 = row x
    | otherwise = col y
    where
      x = smallest (x1-1,x2) (λx.f(x,r)) t
      y = smallest (y2-1,y1) (λy.f(c,y)) t
      c = (x1 +x2) `div` 2
      r = (y1 +y2) `div` 2
      row x | z<t = from (x1,y1) (x2,r +1)
            | z == t = (x,r):from (x1,y1) (x-1,r +1)++from (x+1,r-1) (x2,y2)
            | z>t = from (x1,y1) (x-1,r +1)++from (x,r-1) (x2,y2)
        where z = f (x,r)
      col y | z<t = from (c+1,y1) (x2,y2)
            | z == t = (c,y):from (x1,y1) (c-1,y+1)++from (c+1,y-1) (x2,y2)
            | z>t = from (x1,y1) (c-1,y)++from (c+1,y-1) (x2,y2)
        where z = f (c,y)
