-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/3409878/showzaemon/Haskell
{-# LANGUAGE FlexibleContexts #-}
import Data.List ( foldl' )
import qualified Data.Set as Set
import qualified Data.Sequence as Seq
import qualified Data.ByteString.Char8 as B
import Data.Bits
    ( Bits(xor, shiftL, shiftR, rotateR, (.&.), (.|.)) )
import Data.Array ( listArray, (!) )
import Data.Maybe ( fromJust )
import qualified Data.IntMap as M
import Control.Monad ( replicateM )
 
size = 3
sqSize = size*size
maxAdr = sqSize -1
mask = 0xF
shiftSize = 4
shiftTimes = 16
 
solver :: [[Int]] -> Int
solver lst
  | start == goal = 0
  | otherwise = iter (initialQueue, initialVisited) where
      iter (que, visited) = case Seq.viewr que of
          Seq.EmptyR -> error "No path found."
          que Seq.:> path@(board, distance, forward) -> case next path visited of
              (_, Just d)  -> distance + d +1
              (nextPaths, Nothing) -> iter (insertPaths que visited nextPaths) where
                  insertPaths q v [] = (q, v)
                  insertPaths q v (p@(x, d, f):ps) = insertPaths insertQue insertVisited ps where
                      insertQue = p Seq.<| q
                      insertVisited = M.insert x (d, f) v
      next path@(board, distance, forward) visited = iter [] Nothing nextBoards where
          iter ac af [] = (ac, af)
          iter ac af (x:xs) = case M.lookup x visited of
              Nothing -> iter ((x, distance+1, forward):ac) af xs
              Just (d', f') -> if forward == f' then iter ac af xs else (ac, Just d')
          nextBoards = [swapWith (valueAt p board) board | p <- dest ! searchZero board]
 
      initialQueue = (goal, 0, False) Seq.<| Seq.singleton (start, 0, True)
      initialVisited = M.insert goal (0, False) $ M.singleton start (0, True)
      goal    = toBits [1,2,3,4,5,6,7,8,0]
      start   = toBits $ concat lst
      dest    = listArray (0, maxAdr) [[1,3],[0,2,4],[1,5],[0,4,6],[1,3,5,7],[2,4,8],[3,7],[4,6,8],[5,7]]
      toBits = foldl' (\b a-> shiftL b shiftSize .|. a) 0
      valueAt i w = mask .&. shiftR w (shiftSize*i)
 
searchZero :: Int -> Int
searchZero = iter 0 where
  iter c w = case mask .&. w of
    hb | hb == 0 -> c
       | otherwise -> iter (c+1) (rotateR w shiftSize)
 
swapWith :: Int -> Int -> Int
swapWith v = iter sqSize where
  iter 0 w = rotateR w (shiftSize*(shiftTimes-sqSize))
  iter c w = iter (c-1) $ rotateR (case mask .&. w of
    hb | hb == 0 -> w .|. v
       | hb == v -> w `xor` v
       | otherwise -> w) shiftSize
 
readIntLn:: IO Int
readIntLn = fmap (fst . fromJust . B.readInt) B.getLine
 
readIntList:: IO [Int]
readIntList = fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine
 
main :: IO()
main = do
  l <- replicateM size readIntList
  print $ solver l
