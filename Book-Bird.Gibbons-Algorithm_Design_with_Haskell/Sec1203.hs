module Sec1203 where
import Lib (Nat,foldrn,minWith)
import Sec1201 (Partition,bind,extendr,snoc)
-- P.294 12.3 The paragraph problem
type MyWord = [Char] -- 本来はWord
type Text = [MyWord]
type Para = [Line]
type Line = [MyWord]

-- P.295
-- para :: Text -> Para
-- para ← MinWith cost ・filter (all fits)・parts
maxWidth :: Nat
maxWidth = 16 -- constant
fits :: Line -> Bool
fits line = width line <= maxWidth
width :: Line -> Nat
width = foldrn add length where add w n = length w+1+n

-- P.295
fitParts :: Foldable t => t MyWord -> [[Line]]
fitParts = foldl (flip (concatMap . fitExtend)) [[]]
  where fitExtend x = filter (fits . last) . extendr x

-- P.296
cost1 :: [Line] -> Nat
cost1 = length
-- P.296
cost2 :: [Line] -> Nat
cost2 = sum . map waste . init
  where waste line = maxWidth - width line
-- P.296
optWidth = maxWidth
cost3 :: [Line] -> Nat
cost3 = sum . map waste . init where 
  waste line = (optWidth - width line)^2
-- P.296
cost4 :: [Line] -> Nat
cost4 = foldr (max . waste) 0 . init
  where waste line = maxWidth - width line
cost5 :: [Line] -> Nat
cost5 = foldr (max . waste) 0 . init
  where waste line = (optWidth - width line)^2

-- P.296
greedy :: Foldable t => t MyWord -> Partition MyWord
greedy = foldl add [] where
  add [] w = snoc w []
  add p w = head (filter (fits . last) [bind w p, snoc w p])

-- P.297
cost11 :: [Line] -> (Int, Nat)
cost11 p = (length p, width (last p))

-- P.299
para :: Text -> Para
para = minWith cost . foldl tstep [[]] where
  cost = cost1 -- 適当に選ぶ
  tstep [[]] w = [[[w]]]
  tstep ps w = minWith cost (map (snoc w) ps):
    filter (fits . last) (map (bind w) ps)
