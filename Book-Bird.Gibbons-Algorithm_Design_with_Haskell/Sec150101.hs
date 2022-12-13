module Sec150101 where
import Lib (Nat)
-- P.369 15.1 Implicit search and the n-queens problem

-- P.369
-- solutions = filter good . candidates
-- solution = head . solutions

-- P.370
safe :: [Nat] -> Bool
safe qs = check (zip [1..] qs)
check :: (Eq a, Num a) => [(a, a)] -> Bool
check [] = True
check ((r,q):rqs) = and [abs (q-q') /= r'-r | (r',q') <- rqs]
  && check rqs

-- P.370
queens :: Nat -> [[Nat]]
queens = filter safe . perms

-- P.370
perms :: (Num t, Enum t) => t -> [[t]]
perms n = foldr (concatMap . inserts) [[]] [1..n] where
  inserts x [] = [[x]]
  inserts x (y:ys) = (x:y:ys):map (y:) (inserts x ys)

-- P.371
--safe (qs ++ [q]) = safe qs && newDiag q qs
newDiag :: Int -> [Int] -> Bool
newDiag q qs = and [abs (q-q') /= r-r' | (r',q') <- zip [1..] qs]
  where r = length qs+1
perms2 :: (Num a, Enum a, Eq a) => a -> [[a]]
perms2 n = help n where
  help 0 = [[]]
  help r = [xs++[x] | xs <- help (r-1), x <- [1..n], x `notElem` xs]

-- P.388
queens1 :: (Eq a, Num a, Enum a) => a -> [[a]]
queens1 n = help n where
  help 0 = [[]]
  help r = [qs++[q] | qs <- help (r-1), q <- [1..n],
            q `notElem` qs, newDiag1 (r,q) qs]
newDiag1 :: (Num a, Enum a, Eq a) => (a, a) -> [a] -> Bool
newDiag1 (r,q) qs = and [abs (q-q') /= r-r' | (r',q') <- zip [1..] qs]

-- P.388
queens2 :: (Num a, Enum a, Eq a) => a -> [[a]]
queens2 n = help n where
  help 0 = [[]]
  help r = [q:qs | q <- [1..n], qs <- qss,
            q `notElem` qs, newDiag2 q qs]
    where qss = help (r-1)
newDiag2 :: (Num a, Enum a, Eq a) => a -> [a] -> Bool
newDiag2 q qs = and [abs (q-q') /= r'-1 | (r',q') <- zip [2..] qs]

-- P.373
solutions :: State -> [State]
solutions t = search [t]
search::[State] -> [State]
search [] = []
search (t:ts) = if solved t then t :search ts else search (succs t++ts)
succs :: State -> [State]
succs t = [move t m | m <- moves t]

-- P.373
type State = [Nat]
type Move = Nat
-- P.373, for n-queen problem
n :: Int
n = 10
-- P.372, P.373
moves :: State -> [Move]
moves qs = [q | q <- [1..n], q `notElem` qs, newDiag2 q qs]
-- P.372, P.373
move :: State -> Move -> State
move qs q = q:qs
-- P.372, P.373
solved :: State -> Bool
solved qs = length qs == n
