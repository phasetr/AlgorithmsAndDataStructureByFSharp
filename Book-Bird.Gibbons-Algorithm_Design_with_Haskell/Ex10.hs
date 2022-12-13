module Ex10 where
import Data.Array
import Lib (minWith)

-- P.261 Answer10.2
thinBy1 (≼) = foldl bump [] . reverse where
  bump [] x = [x]
  bump (y:ys) x
    | x ≼ y = x:ys
    | y ≼ x = y:ys
    | otherwise = x:y:ys

thinBy2 :: (a -> a -> Bool) -> [a] -> [a]
thinBy2 (≼) [ ] = [ ]
thinBy2 (≼) [x] = [x]
thinBy2 (≼) (x:y:xs)
  | x ≼ y = thinBy2 (≼) (x:xs)
  | y ≼ x = thinBy2 (≼) (y:xs)
  | otherwise = x:thinBy2 (≼) (y:xs)

{-
-- P.261 Answer10.3
-- You can assume a function subseqs::[a] → [[a]]
-- that returns all the subsequences of a sequence.
candidates (≼) xs = [ys | ys <- subseqs xs,ok xs ys]
  where ok xs ys = and [or [y ≼ x | y <- ys] | x <- xs]
-}

-- P.261 Answer 10.4
thinBy3 (≼) = foldr gstep [ ]
  where gstep x ys = if any (≼ x) ys then ys else x:filter (not . (x ≼)) ys
-- P.261 Answer 10.6
thinBy (≼) [] = []
thinBy (≼) [x] = [x]
thinBy (≼) (x:y:xs) = if x ≼ y then x:xs else x:thinBy (≼) (y:xs)
-- thinBy (≼) [1,2,3] == [1,3]
-- thinBy (≼) [2,1,3] == [2,1]

-- P.263 Answer 10.14
mcp :: Nat -> Net -> Path
mcp k = snd . minWith fst . elems . foldr step start
  where
    start = array (1,k) [(v,(0,[])) | v <- [1..k]]
    step es pa = accumArray better initial (1,k) (map insert es)
      where
        initial = (maxInt,[])
        insert (u,v,w) = (u,(add w c,(u,v,w):p))
          where (c,p) = pa!v
    better (c1,p1) (c2,p2) = if c1 <= c2 then (c1,p1) else (c2,p2)

maxInt ::Int
maxInt = maxBound
add w c = if c == maxInt then maxInt else w+c

-- P.263 Answer 10.15 One definition is
mergeBy :: (a -> a -> Bool) -> [[a]] -> [a]
mergeBy cmp = foldr merge [] where
  merge xs [] = xs
  merge [] ys = ys
  merge (x:xs) (y:ys)
    | cmp x y = x:merge xs (y:ys)
    | otherwise = y:merge (x:xs) ys

-- P.264 Answer10.18
mkchange n = coins・last ・foldr tstep [([],n,0)]

-- P.264 Answer10.19
extend i sn = sn:filter (within w) [add i sn]

-- P.264 Answer10.21
swag w = maxWith value . foldr tstep [([],0,0)] where
  tstep i sns = thinBy (≼) (mergeBy cmp [sns,sns'])
    where
      sns' = filter (within w) (map (add i) sns)
      cmp sn1 sn2 = weight sn1 <= weight sn2

-- P.264 Answer10.22
cost :: Selection -> (Value,Weight)
cost sn = (value sn, negate (weight sn))

maxWith value =  maxBy (≼)
sn1 ≼ sn2 = value sn1 < value sn2 ||
  (value sn1 == value sn2 && weight sn1 >= weight sn2)

maxBy :: (a -> a -> Bool) -> [a] -> a
maxBy (≼) = foldr1 higher where
  higher x y = if x ≼ y then y else x
