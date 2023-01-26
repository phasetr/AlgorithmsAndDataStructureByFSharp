-- https://atcoder.jp/contests/tessoku-book/submissions/37275639
import Control.Monad (replicateM)
import Data.Array.IArray (Array, accumArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.Heap (Entry (Entry))
import qualified Data.Heap as Heap
import qualified Data.IntMap.Strict as IM
import qualified Data.IntSet as IS
import Data.List (foldl', unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

graph :: (Int, Int) -> [[Int]] -> Array Int [(Int, Int)]
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs where
  xs = concatMap (\[u, v, w] -> [(u, (v, w)), (v, (u, w))]) uvs

-- Entry Int Int ･･･ コスト (priority) 頂点番号 (payload)
type Node = Entry Int Int

dijkstra :: Array Int [(Int, Int)] -> Node -> IM.IntMap Int -> IM.IntMap Int
dijkstra g start = f (Just (start, Heap.empty)) IS.empty where
  f :: Maybe (Node, Heap.Heap Node) -> IS.IntSet -> IM.IntMap Int -> IM.IntMap Int
  f Nothing _ nodes = nodes
  f (Just (Entry currentCost i, q)) done nodes
    | IS.member i done = f (Heap.uncons q) done nodes
    | otherwise = f (Heap.uncons q') done' nodes'
    where
      done' = IS.insert i done
      edges = g ! i
      (q', nodes') = foldl' (relax currentCost) (q, nodes) edges

  relax currentCost (q, nodes) (v, w) = (q', nodes') where
      cost = currentCost + w
      nodes' = IM.adjust (`min` cost) v nodes
      q'
        | cost < nodes IM.! v = Heap.insert (Entry cost v) q
        | otherwise = q

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs
      start = Entry 0 1
      nodes = IM.fromList $ (1, 0) : [(k, maxBound :: Int) | k <- [2 .. n]]

  let result = dijkstra g start nodes

  mapM_ (\(_, w) -> print $ if w /= (maxBound :: Int) then w else -1) (IM.toAscList result)
