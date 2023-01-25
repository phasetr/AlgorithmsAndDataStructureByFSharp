-- https://atcoder.jp/contests/tessoku-book/submissions/36403124
{-# LANGUAGE TupleSections #-}
{-# LANGUAGE TypeApplications #-}

import Control.Monad (join, replicateM)
import Data.Array (Array)
import Data.Array.Unboxed (UArray, accumArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import qualified Data.IntSet as Set
import Data.List (unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

graph :: (Int, Int) -> [[Int]] -> Array Int [Int]
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs where
  xs = concatMap (\[u, v] -> [(u, v), (v, u)]) uvs

runBFS :: (Int -> [Int]) -> Int -> [[Int]]
runBFS f v0 = bfs (Set.singleton v0) Set.empty where
  bfs :: Set.IntSet -> Set.IntSet -> [[Int]]
  bfs current visited
    | Set.null current = []
    | otherwise = Set.elems current : bfs next visited'
    where
      visited' = Set.union visited current
      next =
        let vs = Set.fromList $ concatMap f (Set.elems current)
        in Set.difference vs visited'

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs
      routes = runBFS (g !) 1
      rc = join $ zipWith (\i vs -> map (,i) vs) [1 :: Int ..] routes
      results = accumArray @UArray (+) (-1) (1, n) rc

  mapM_ (\v -> print $ results ! v) [1 .. n]
