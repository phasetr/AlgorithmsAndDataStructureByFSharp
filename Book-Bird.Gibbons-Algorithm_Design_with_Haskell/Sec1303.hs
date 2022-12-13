module Sec1303 where
import Lib (Nat,minWith)
import Data.List (tails)
-- P.319 13.3 Minimum-cost edit sequences
data Op = Copy Char | Replace Char Char | Delete Char | Insert Char

-- P.319
reconstruct :: [Op] -> ([Char],[Char])
reconstruct = foldr step ([],[]) where
  step (Copy x) (us,vs)      = (x:us,x:vs)
  step (Replace x y) (us,vs) = (x:us,y:vs)
  step (Insert x) (us,vs)    = (us,x:vs)
  step (Delete x) (us,vs)    = (x:us,vs)

-- P.320
cost :: [Op] -> Nat
cost = sum . map ecost

ecost :: Num p => Op -> p
ecost (Copy x) = 0
ecost (Replace x y) = 3
ecost (Delete x) = 2
ecost (Insert y) = 2

{-
-- P.320, mce (a minimum-cost edit)
mce :: [Char] -> [Char] -> [Op]
mce xs ys ← MinWith cost (edits xs ys)
-}
-- P.320
edits :: [Char] -> [Char] -> [[Op]]
edits xs [] = [map Delete xs]
edits [] ys = [map Insert ys]
edits (x:xs) (y:ys) = [pick x y:es | es <- edits xs ys]
                      ++[Delete x:es | es <- edits xs (y:ys)]
                      ++[Insert y:es | es <- edits (x:xs) ys]
pick :: Char -> Char -> Op
pick x y = if x == y then Copy x else Replace x y
-- cost es1 <= cost es2 => cost (op:es1) <= cost (op:es2)

-- P.320
mce :: [Char] -> [Char] -> [Op]
mce xs [] = map Delete xs
mce [] ys = map Insert ys
mce (x:xs) (y:ys) = minWith cost [ pick x y:mce xs ys
                                 , Delete x:mce xs (y:ys)
                                 , Insert y:mce (x:xs) ys]

-- P.321
mce2 :: [Char] -> [Char] -> [Op]
mce2 (x:xs) (y:ys) =
  if x == y then Copy x:mce2 xs ys
  else minWith cost [ Replace x y:mce2 xs ys
                    , Delete x:mce2 xs (y:ys)
                    , Insert y:mce2 (x:xs) ys]
mce2 _ _ = error "undefined"

-- P.321
mce3 :: [Char] -> [Char] -> [Op]
mce3 xs ys = head (foldr (nextrow xs) (firstrow xs) ys) where
  firstrow = tails . map Delete
-- P.321
nextrow :: [Char] -> Char -> [[Op]] -> [[Op]]
nextrow xs y row = foldr step [Insert y:last row] xes where
  xes = zip3 xs row (tail row)
  step (x,es1,es2) row = if x == y then (Copy x:es2):row
    else minWith cost [ Replace x y:es2
                      , Delete x:head row
                      , Insert y:es1]:row
