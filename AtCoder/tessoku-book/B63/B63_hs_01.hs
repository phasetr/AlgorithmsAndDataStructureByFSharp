-- https://atcoder.jp/contests/tessoku-book/submissions/36405038
{-# LANGUAGE TypeApplications #-}
import Control.Monad (replicateM)
import Data.Array.Unboxed (Array, UArray, listArray, (!))
import Data.List (findIndex)
import Data.Maybe (fromJust)
import qualified Data.Set as S

to :: (Int, Int) -> (Int, Int) -> (Int, Int)
to (x, y) (x', y') = (x + x', y + y')

around :: (Int, Int) -> [(Int, Int)]
around xy = map (xy `to`) [(1, 0), (0, 1), (-1, 0), (0, -1)]

check :: Array Int (UArray Int Char) -> (Int, Int) -> Bool
check s (x, y)
  | s ! x ! y == '#' = False
  | otherwise = True

bfs :: ((Int, Int) -> [(Int, Int)]) -> (Int, Int) -> [[(Int, Int)]]
bfs f xy = aux (S.singleton xy) S.empty where
  aux :: S.Set (Int, Int) -> S.Set (Int, Int) -> [[(Int, Int)]]
  aux current visited
    | S.null current = []
    | otherwise = S.elems current : aux next visited'
    where
      visited' = S.union visited current
      next =
        let vs = S.fromList $ concatMap f (S.elems current)
         in S.difference vs visited'

getInts :: IO [Int]
getInts = map read . words <$> getLine

main :: IO ()
main = do
  [[r, c], [sy, sx], [gy, gx]] <- replicateM 3 getInts
  cs <- replicateM r getLine

  let maze = listArray @Array (1, r) $ map (listArray @UArray (1, c)) cs
      result = bfs (filter (check maze) . around) (sy, sx)

  print $ fromJust $ findIndex ((gy, gx) `elem`) result

test = do
  let (r,c,sy,sx,gy,gx,cs) = (7,8,2,2,4,5,["########","#......#","#.######","#..#...#","#..##..#","##.....#","########"])
  let maze = listArray @Array (1, r) $ map (listArray @UArray (1, c)) cs
  print maze
