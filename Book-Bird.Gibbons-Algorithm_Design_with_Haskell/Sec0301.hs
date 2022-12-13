module Sec0301 where
import Lib (Nat, single)

-- P.043
type SymList a = ([a],[a])

-- P.044
fromSL :: SymList a -> [a]
fromSL (xs,ys) = xs ++ reverse ys

-- P.044
-- P.044
snocSL :: a -> SymList a -> SymList a
snocSL x (xs,ys) = if null xs then (ys, [x]) else (xs,x:ys)

-- P.044
lastSL :: SymList a -> a
lastSL (xs,ys) = if null ys then head xs else head ys
-- P.045
tailSL :: SymList a -> SymList a
tailSL (xs,ys)
  | null xs = if null ys then undefined else nilSL
  | single xs = (reverse vs, us)
  | otherwise = (tail xs, ys)
  where (us,vs) = splitAt (length ys `div` 2) ys

-- P.056, Answer3.2
nilSL :: SymList a
nilSL = ([],[])
-- P.056, Answer3.2
nullSL :: SymList a -> Bool
nullSL (xs,ys) = null xs && null ys
-- P.056, Answer3.2
singleSL :: SymList a -> Bool
singleSL (xs,ys) = (null xs && single ys) || (null ys && single xs)
-- P.056, Answer3.2
lengthSL :: SymList a -> Nat
lengthSL (xs,ys) = length xs + length ys

-- P.056, Answer3.3
consSL :: a -> SymList a -> SymList a
consSL x (xs,ys) = if null ys then ([x],xs) else (x:xs,ys)
-- P.056, Answer3.3
headSL :: SymList a -> a
headSL (xs,ys) = if null xs then head ys else head xs

-- P.056, Answer3.4
initSL :: SymList a -> SymList a
initSL (xs,ys)
  | null ys = if null xs then undefined else nilSL
  | single ys = (us, reverse vs)
  | otherwise = (xs, tail ys)
  where (us,vs) = splitAt (length xs `div` 2) xs

-- P.056, Answer3.5
dropWhileSL :: (a -> Bool) -> SymList a -> SymList a
dropWhileSL p xs
  | nullSL xs = nilSL
  | p (headSL xs) = dropWhileSL p (tailSL xs)
  | otherwise = xs

-- P.057, Answer3.6
initsSL :: SymList a -> SymList (SymList a)
initsSL xs =
  if nullSL xs then snocSL xs nilSL
  else snocSL xs (initsSL (initSL xs))
