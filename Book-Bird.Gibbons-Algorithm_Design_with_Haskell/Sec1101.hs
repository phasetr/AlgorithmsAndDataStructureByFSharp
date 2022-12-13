module Sec1101 where
-- P.267, 11.1 The longest upsequence
{-
-- P.267, longest upsequence
lus :: Ord a => [a] -> [a]
lus <- MaxWith length . filter up . subseqs
-}

-- P.267
up :: Ord a => [a] -> Bool
up xs = and $ zipWith (<) xs (tail xs)

-- P.268
subseqs :: [a] -> [[a]]
subseqs = foldr step [[]] where
  step x xss = xss ++ map (x:) xss

subseqs2 :: [a] -> [[a]]
subseqs2 = foldr (concatMap . extend) [[]] where
  extend x xs = [xs, x:xs]

{-
-- P.268
lus <- MaxWith length・foldr step [[]]
  where
    step x xss = xss ++ map (x:) (filter (ok x) xss)
    ok x ys = null ys && x<head ys
-}

-- P.269
(≼) :: Ord a => [a] -> [a] -> Bool
[]     ≼ []     = True
(x:xs) ≼ []     = False
[]     ≼ (y:ys) = False
(x:xs) ≼ (y:ys) = x >= y && length xs >= length ys

-- P.242
thinBy :: Foldable t => (a -> a -> Bool) -> t a -> [a]
thinBy (≼) = foldr bump [] where
  bump x [] = [x]
  bump x (y:ys)
    | x ≼ y = x:ys
    | y ≼ x = y:ys
    | otherwise = x:y:ys

{-
-- P.269
tstep :: t1 -> t2 -> [[a]]
tstep x xss = thinBy (≼) (step x xss)
-}

-- P.261, Answer10.3
ok :: Ord a => [[a]] -> [[a]] -> Bool
ok xs ys = and [or [y ≼ x | y <- ys] | x <- xs]
-- P.265, Answer10.15
mergeBy :: (a -> a -> Bool) -> [[a]] -> [a]
mergeBy cmp = foldr merge [] where
  merge xs [] = xs
  merge [] ys = ys
  merge (x:xs) (y:ys)
    | cmp x y = x:merge xs (y:ys)
    | otherwise = y:merge (x:xs) ys

-- P.269
lus :: Ord a => [a] -> [a]
lus = last . foldr tstep [[]]

{-
-- P.269
tstep :: a -> [[a]] -> [[a]]
tstep x xss = thinBy (≼) (mergeBy cmp [xss,yss]) where
  yss = map (x:) (filter (ok x) xss)
  cmp xs ys = length xs <= length ys
-}

-- P.270
tstep x ([]:xss) = []: search x [] xss where
  search x xs [] = [x:xs]
  search x xs (ys:yss)
    | head ys > x = ys : search x ys xss
    | otherwise = (x:xs) : xss
tstep _ _ = error "do not come here"
