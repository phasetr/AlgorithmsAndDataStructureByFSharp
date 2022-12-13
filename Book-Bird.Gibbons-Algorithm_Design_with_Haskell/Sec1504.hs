module Sec1504 where
import Lib (Nat)

-- P.383 15.4 Lunar Landing
type Cell = Nat
type Board = [Cell]
solved :: Board -> Bool
solved b = head b == 15

-- P.385
type Name = Nat
type Move = (Name,Cell,Cell)
showMove :: Move -> String
showMove (n,s,f) = show n++dir (s,f)
--dir (s,f) = if abs (s-f) >= 6 then (if s<f then "D" else "U")
--  else (if s<f then "R" else "L")
dir :: (Ord a, Num a) => (a, a) -> [Char]
dir (s,f) =
  case (abs (s-f) >= 6, s<f) of
    (True,True) -> "D"
    (True,False) -> "U"
    (False,True) -> "R"
    _ -> "L"
move :: Board -> Move -> Board
move b (n,s,f) = b1 ++f :b2 where (b1,_:b2) = splitAt n b

-- P.386
moves :: Board -> [Move]
moves b = [(n,s,f) | (n,s) <- zip [0..] b, f <- targets b s]

-- P.386
targets :: Board -> Cell -> [Cell]
targets b c = concatMap try [ups c,downs c,lefts c,rights c] where
  try cs | null ys = []
         | null xs = []
         | otherwise = [last xs]
    where (xs,ys) = span (`notElem` b) cs
  ups c = [c-6,c-12..1]
  downs c = [c+6,c+12..29]
  lefts c = [c-1,c-2..c-c `mod` 6+1]
  rights c = [c+1,c+2..c-c `mod` 6+5]
-- breadth-width search!
-- safeLandings :: a -> [[String]]
-- safeLandings = map (map showMove) . solutions
