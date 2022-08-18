module DivideAndConquer where

-- P.155, 8.1 Divide-and-conquer
-- | P.157
divideAndConquer :: (p -> Bool) -> (p -> s) -> (p -> [p]) -> (p -> [s] -> s) -> p -> s
divideAndConquer ind solve divide combine = dc' where
  dc' pb
    | ind pb  = solve pb
    | otherwise = combine pb (map dc' (divide pb))

-- | P.157, 8.1.2 Mergesort
msort :: Ord a => [a] -> [a]
msort xs = divideAndConquer ind id divide combine xs where
  ind xs            = length xs <= 1
  divide xs         = [take n xs, drop n xs] where n = length xs `div` 2
  combine _ [l1,l2] = merge l1 l2
  combine _ _       = undefined

-- | From Section6.3.4
merge :: (Ord a) => [a] -> [a] -> [a]
merge [] b = b
merge a [] = a
merge a@(x:xs) b@(y:ys)
  | x<=y      = x : merge xs b
  | otherwise = y : merge a ys

-- | P.158 8.1.3 Quicksort
qsort :: Ord a => [a] -> [a]
qsort xs = divideAndConquer ind id divide combine xs where
  ind xs                = length xs <= 1
  divide (x:xs)         = [[y | y<-xs, y<=x], [y | y<-xs, y>x]]
  divide _              = undefined
  combine (x:_) [l1,l2] = l1 ++ [x] ++ l2
  combine _ _           = undefined
