module Sec1503 where
import Lib (Nat)
import Data.Set (empty,insert,member)
import Sec150101 (Move,State,move,moves,solved)
--import Sec150102 (Move)

-- P.395 15.3 Depth-first and breadth-first search
-- moves :: State -> [Move]
-- move :: State -> Move -> State
-- solved ::State -> Bool
-- P.379
type Path = ([Move],[State])

-- P.379
succs :: Path -> [Path]
succs (ms,t:ts) = [(ms++[m], t':t:ts)
                  | m <- moves t, let t' = move t m, t' `notElem` ts]
succs _ = error "undefined"
final :: Path -> State
final = head . snd
paths1 :: [Path] -> [Path]
paths1 = concat . takeWhile (not . null) . iterate (concatMap succs)
paths2 :: [Path] -> [Path]
paths2 ps = concat [p:paths2 (succs p) | p <- ps]

-- P.380
solutions1 :: State -> [[Move]]
solutions1 = map fst . filter (solved . final). paths1 . start
start :: State -> [Path]
start t = [([ ],[t])]
-- P.381
solutions11 :: State -> [[Move]]
solutions11 = search . start where
  search [] = []
  search ((ms,t :ts):ps)
    | solved t = ms:search ps
    | otherwise = search (ps++succs (ms,t:ts))
  search _ = error "undefined"
-- P.381
solutions2 :: State -> [[Move]]
solutions2 = search . start where
  search [] = []
  search ((ms,t :ts):ps)
    | solved t = ms:search ps
    | otherwise = search (succs (ms,t :ts)++ps)
  search _ = error "undefined"

-- P.382
search1 :: [[([Move], [State])]]
  -> [([Move], [State])] -> [([Move], [State])] -> [[Move]]
search1 pss ps = search (ps++concat (reverse pss))
solutions12 :: State -> [[Move]]
solutions12 = search [] . start where
  search [] [] = []
  search pss [] = search [] (concat (reverse pss))
  search pss ((ms,t :ts):ps)
    | solved t = ms:search pss ps
    | otherwise = search (succs (ms,t:ts):pss) ps
  search _ _ = error "undefined"
search :: [([Move], [State])] -> [([Move], [State])] -> [[Move]]
search qs [] = if null qs then [ ] else search [] qs
search qs ((ms,t :ts):ps)
  | solved t = ms:search qs ps
  | otherwise = search (succs (ms,t :ts)++qs) ps
search _ _ = error "undefined"

-- P.383
solution13 :: State -> Maybe [Move]
solution13 t = search [] [([],t)] where
  search ts [] = Nothing
  search ts ((ms,t):ps)
    | solved t = Just ms
    | t `elem` ts = search ts ps
    | otherwise = search (t:ts) (ps++succs (ms,t))
  -- P.382
  succs (ms,t) = [(ms++[m],move t m) | m <- moves t]

-- P.383
solution14 :: State -> Maybe [Move]
solution14 t = search empty [([],t)] where
  search ts [] = Nothing
  search ts ((ms,t):ps)
    | solved t = Just ms
    | member t ts = search ts ps
    | otherwise = search (insert t ts) (ps++succs (ms,t))
  -- P.382
  succs (ms,t) = [(ms++[m],move t m) | m <- moves t]

-- P.383
solution2 :: State -> Maybe [Move]
solution2 t = search empty [([],t)] where
  search ts [] = Nothing
  search ts ((ms,t):ps)
    | solved t = Just ms
    | member t ts = search ts ps
    | otherwise = search (insert t ts) (succs (ms,t)++ps)
  -- P.382
  succs (ms,t) = [(ms++[m],move t m) | m <- moves t]
