-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/3431352/showzaemon/Haskell
{-# LANGUAGE FlexibleContexts #-}

import qualified Data.Set as Set
import qualified Data.Sequence as Seq
import qualified Data.ByteString.Char8 as B
import Data.Array.Unboxed ( (!), (//), array, UArray )
import qualified Data.IntMap as M

solver :: B.ByteString -> B.ByteString -> [Int]
solver w s = iter 0 0 [] where
  iter j k ac
    | j >= ls = reverse ac
    | B.index s j == B.index w k = if k + 1 >= lw
                                   then iter (j+1) (tbl!(k+1)) ((j-k):ac)
                                   else iter (j+1) (k+1) ac
    | tbl!k < 0 = iter (j+1) (tbl!k +1) ac
    | otherwise = iter j (tbl!k) ac
  ls = B.length s
  lw = B.length w
  tbl :: UArray Int Int
  tbl = iter 1 0 $ array (0, lw) [(0,-1)] where
    iter p c t
      | p >= lw = t // [(p, c)]
      | B.index w p == B.index w c = iter (p+1) (c+1) (t // [(p, t!c)])
      | otherwise = iter (p+1) (c'+1) t' where
          c' = iter c where
            iter c
              | c < 0 || B.index w p == B.index w c = c
              | otherwise = iter (t'!c)
          t' = t // [(p, c)]

main :: IO()
main = do
  s <- B.getLine
  w <- B.getLine
  mapM_ print $ solver w s
