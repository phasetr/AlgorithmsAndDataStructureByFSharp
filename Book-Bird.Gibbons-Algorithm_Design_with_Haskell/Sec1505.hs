module Sec1505 where
import Lib (Nat)
import qualified Graphics.Win32 as Answer4
-- P.386 15.5 Forward planning
-- P.389 15.6 Rush Hour
--type Move = Int -- 正しいか不明
type Plan = [Move]
type State = [Nat] -- 正しいか不明

-- P.387
-- gameplan :: State -> Plan
-- premoves :: State -> Move -> [Plan]
-- newplans :: State -> Plan -> [Plan]
-- newplans t [] = []
-- newplans t (m:ms) =
--   if m `elem` moves t then [m:ms]
--   else concat [newplans t (pms++m:ms)
--               | pms <- premoves t m,all (`notElem` ms) pms]

-- P.388
type Path = ([Move],State,Plan)
type Frontier = [Path]

-- P.388
-- psolve ::State -> Maybe [Move]
-- psolve t = psearch [] [] [([],t,gameplan t)] where
--   psearch :: [State] -> Frontier -> Frontier -> Maybe [Move]
--   psearch ts [] [] = Nothing
--   psearch ts qs [] = psearch ts [] qs
--   psearch ts qs ((ms,t,plan):ps)
--     | solved t = Just ms
--     | t `elem` ts = psearch ts qs ps
--     | otherwise = psearch (t :ts) (bsuccs (ms,t,plan)++qs)
--                   (asuccs (ms,t,plan)++ps)
-- asuccs :: Path -> [Path]
-- asuccs (ms,t,plan) = [(ms++[m], move t m,p) | m:p <- newplans t plan]
-- asuccs (ms,t,m:plan) = [(ms++[m], move t m,plan)]
-- bsuccs :: Path -> [Path]
-- bsuccs (ms,t,_) = [(ms++[m], t', gameplan t')
--                   | m <- moves t,let t' = move t m]

-- P.90, Answer4.13
merge :: Ord a => [a] -> [a] -> [a]
merge [] ys = ys
merge xs [] = xs
merge (x:xs) (y:ys)
  | x<y = x:merge xs (y:ys)
  | x == y = x:merge xs ys
  | x>y = y:merge (x:xs) ys
merge _ _ = error "undefined"

-- P.389 15.6 Rush Hour
type Cell = Nat
type Vehicle = (Cell,Cell)
type Grid = [Vehicle]
occupied :: Grid -> [Cell]
occupied = foldr merge [] . map fill
fill :: Vehicle -> [Cell]
fill (r,f) = if horizontal (r,f) then [r..f] else [r,r+7..f]
horizontal :: Vehicle -> Bool
horizontal (r,f) = f-r<6
type Name = Nat
type Move = (Name,Cell)
moves :: Grid -> [Move]
moves g = [(n,c) | (n,v) <- zip [0..] g,
            c <- steps v,
            c `notElem` occupied g]

-- P.391
steps :: (Cell, Cell) -> [Cell]
steps (r,f) = if horizontal (r,f)
then [c | c <- [f+1, r-1], c `mod` 7 /= 0]
else [c | c <- [f+7, r-7], 0<c && c<42]
move :: Grid -> Move -> Grid
move g (n,c) = g1 ++ [adjust v c] ++ g2
  where (g1,v:g2) = splitAt n g
adjust :: Vehicle -> Cell -> Vehicle
adjust (r,f) c = if f <c then (c-f+r,c) else (c, c+f-r)
solved :: Grid -> Bool
solved g = snd (head g) == 20
-- P.391
newplans :: Grid -> Plan -> [Plan]
newplans g [] = []
newplans g (m:ms) = mkplans (expand g m++ms)
  where mkplans (m:ms) =
          if m `elem` moves g then [m:ms] else
            concat [newplans g (pms++m:ms)
                   | pms <- premoves g m,all (`notElem` ms) pms]
        mkplans _ = error "underscore"

-- P.392
expand :: Grid -> Move -> [Move]
expand g (n,c) = if horizontal (r,f)
  then if f<c then [(n,d) | d <- [f+1..c]]
       else [(n,d) | d <- [r-1, r-2..c]]
  else if f<c then [(n,d) | d <- [f+7, f+14..c]]
       else [(n,d) | d <- [r-7, r-17..c]]
  where (r,f) = g!!n

-- P.392
gameplan :: Grid -> Plan
gameplan g = [(0,20)]
premoves :: Grid -> Move -> [Plan]
premoves g (n,c) = [[m] | m <- freeingmoves c (blocker g c)]
blocker :: Grid -> Cell -> (Name,Vehicle)
blocker g c = head [(n,v) | (n,v) <- zip [0..] g, c `elem` fill v]

-- P.393
freeingmoves :: Cell -> (Name,Vehicle) -> [Move]
freeingmoves c (n,(r,f)) =
  if horizontal (r,f)
  then [(n,j) | j <- [c-(f-r+1), c+(f-r+1)], a<j && j<b]
  else [(n,j) | j <- [c-(f-r+7), c+(f-r+7)], 0<j && j<42]
  where a = r-r `mod` 7; b = f - f `mod` 7 + 7
