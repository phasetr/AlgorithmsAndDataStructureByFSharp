module Sec1102 where
import Sec1101 (thinBy)
-- P.270 11.2 The longest common subsequence
{-
-- P.270
lcs :: Eq a => [a] -> [a] -> [a]
-- P.271
lcs xs ys <- MaxWith length (intersect (subseqs xs) (subseqs ys))
lcs xs <- MaxWith length . filter (sub xs) . subseqs
-}

-- P.271
sub xs [] = True
sub [] (y:ys) = False
sub (x:xs) (y:ys) = if x==y then sub xs ys else sub xs (y:ys)

-- P.271
lcs [] ys = []
lcs xs [] = []
lcs (x:xs) (y:ys) = if x==y then x:lcs xs ys
                    else longer (lcs (x:xs) ys) (lcs xs (y:ys))

longer :: [a] -> [a] -> [a]
longer xs ys = if length xs < length ys then ys else xs

{-
-- P.271
lcs xs ys = decode (lus (encode xs ys)) ys
-}

{-
-- P.272
lcs xs <- MaxWith length・foldr step [[]] where
  step y yss = yss ++ filter (sub xs) (map (y:) yss)
-}

-- P.263, Answer10.15
mergeBy :: (a -> a -> Bool) -> [[a]] -> [a]
mergeBy cmp = foldr merge [] where
  merge xs [] = xs
  merge [] ys = ys
  merge (x:xs) (y:ys)
    | cmp x y = x:merge xs (y:ys)
    | otherwise = y:merge (x:xs) ys

-- P.273
lcs2 xs = head . foldr tstep [[]] where
  tstep y yss = thinBy (≼) (mergeBy cmp [yss,zss]) where
    zss = dropWhile negpos (map (y:) yss)
    negpos ys = position xs ys < 0
    ys ≼ zs = length ys >= length zs &&
              position xs ys >= position xs zs
    cmp ys zs = position xs ys <= position xs zs

-- P.283, Exercise11.10
position :: Eq a => [a] -> p -> Int
position xs ys = help (length xs) (reverse xs) (reverse xs) where
  help p xs [] = p
  help p [] ys = -1
  help p (x:xs) (y:ys)
    | x == y = help (p-1) xs ys
    | otherwise = help (p-1) xs (y:ys)

-- P.273
cons x (p,k,ws,us) = (p-1-length as, k+1, tail bs, x:us)
  where (as,bs) = span (/= x) ws
-- cons 'b' (3,2,"aab","ba") == (0,3,"","bba")
-- cons 'x' (3,2,"aab","ba") == (-1,3,undefined,"bba")

-- P.273
lcs3 xs = ext . head . foldr tstep start where
  start = [(length xs, 0, reverse xs, [])]
  tstep y yss = thinBy (≼) (mergeBy cmp [yss,zss]) where
    zss = dropWhile negpos (map (cons y) yss)
    negpos ys = psn ys < 0
    q1 ≼ q2 = psn q1 ≼ psn q2 && lng q1 ≼ lng q2
    cmp q1 q2 = psn q1 ≼ psn q2
    ext (p,k,ws,us) = us
    psn (p,k,ws,us) = p
    lng (p,k,ws,us) = k
