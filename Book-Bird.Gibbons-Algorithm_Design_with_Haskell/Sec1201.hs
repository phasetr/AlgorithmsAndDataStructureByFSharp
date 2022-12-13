module Sec1201 where
-- P.289, 12.1 Ways of generating partitions
type Partition a = [Segment a]
type Segment a = [a]

-- P.289
parts :: [a] -> [Partition a]
parts [] = [[]]
parts xs = [ys:yss | (ys,zs) <- splits xs, yss <- parts zs]

-- P.290
splits :: [a] -> [([a],[a])]
splits [] = []
splits (x:xs) = ([x],xs):[(x:ys,zs) | (ys,zs) <- splits xs]

-- P.290
parts2 :: [a] -> [Partition a]
parts2 = foldr (concatMap . extendl) [[]]
extendl :: a -> Partition a -> [Partition a]
extendl x [] = [cons x []]
extendl x p = [cons x p,glue x p]
cons, glue :: a -> Partition a -> Partition a
cons x p = [x]:p
glue x (s:p) = (x:s):p
glue _ _ = error "undefined"

-- P.290
parts3 :: [a] -> [Partition a]
parts3 = foldl (flip (concatMap . extendr)) [[]]
extendr :: a -> Partition a -> [Partition a]
extendr x [] = [snoc x []]
extendr x p = [snoc x p,bind x p]
snoc, bind :: a -> Partition a -> Partition a
snoc x p = p++[[x]]
bind x p = init p++[last p++[x]]
