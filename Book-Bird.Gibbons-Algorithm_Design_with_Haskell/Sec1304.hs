module Sec1304 where
import Sec1102 (longer)
-- P.322 13.4 Longest common subsequence revisited

-- P.322, Chapter11
lcs11 :: Eq a => [a] -> [a] -> [a]
lcs11 [] ys = []
lcs11 xs [] = []
lcs11 (x:xs) (y:ys) =
  if x == y then x:lcs xs ys
  else longer (lcs11 (x:xs) ys) (lcs11 xs (y:ys))

-- P.322
lcs :: (Foldable t, Eq a) => [a] -> t a -> [a]
lcs xs = head . foldr (nextrow xs) (firstrow xs) where
  firstrow xs = replicate (length xs+1) []
  nextrow xs y row = foldr (step y) [[]] (zip3 xs row (tail row))
  step y (x,cs1,cs2) row =
    if x == y then (x:cs2):row
    else longer cs1 (head row):row
