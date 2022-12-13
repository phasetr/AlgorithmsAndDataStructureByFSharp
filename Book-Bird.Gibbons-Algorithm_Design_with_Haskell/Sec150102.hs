module Sec150102 where
import Data.Bits (Bits((.&.),shiftL,shiftR,complement,(.|.)))
import Data.Word (Word16)
import Lib (Nat)
import Sec150101 (move,moves)
-- P.373, for n-queen problem
n :: Int
n = 10

-- P.375
mask :: Word16
mask = 2^n-1
-- P.375
type State = (Word16,Word16,Word16)
type Move = Word16
cqueens :: Nat -> Integer
cqueens n = search [(0,0,0)] where
  search :: [State] -> Integer
  search [] = 0
  search (t :ts) = if solved t then 1+search ts else search (succs t++ts)
  solved :: State -> Bool
  solved (_,cls,_) = cls == mask
  mask :: Word16
  mask = 2^n-1
  succs :: State -> [State]
  succs t = [move t b | b <- moves t]
  move:: State -> Move -> State
  move (lds,cls,rds) m = (shiftL (lds .|. m) 1,cls .|. m,shiftR (rds .|. m) 1)
  moves :: State -> [Move]
  moves (lds,cls,rds) = bits (complement (lds .|. cls .|. rds) .&. mask)

-- P.375
bits :: Word16 -> [Move]
bits v = if v == 0 then [] else b:bits (v-b)
  where b = v .&. negate v
-- bits 11010 == [00010,01000,10000]
-- 11010 .&. negate 11010 == 11010 .&. 00110 = 00010
