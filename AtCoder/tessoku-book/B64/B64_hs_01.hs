-- https://atcoder.jp/contests/tessoku-book/submissions/37276008
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
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs
  where
    xs = concatMap (\[u, v, w] -> [(u, (v, w)), (v, (u, w))]) uvs

-- Entry Int Int ･･･ コスト (priority) 頂点番号 (payload)
type Node = Entry Int Int

-- IntMap に (1つ前の頂点, 最少コスト) を記録する
dijkstra :: Array Int [(Int, Int)] -> Int -> Int -> IM.IntMap (Int, Int)
dijkstra g n v0 = f (Just (start, Heap.empty)) IS.empty initialNodes
  where
    start = Entry 0 v0
    initialNodes = IM.fromList $ (v0, (-1, 0)) : [(k, (-1, maxBound :: Int)) | k <- [2 .. n]]

    f :: Maybe (Node, Heap.Heap Node) -> IS.IntSet -> IM.IntMap (Int, Int) -> IM.IntMap (Int, Int)
    f Nothing _ nodes = nodes
    f (Just (Entry cost i, q)) done nodes
      | IS.member i done = f (Heap.uncons q) done nodes
      | otherwise = f (Heap.uncons q') done' nodes'
      where
        done' = IS.insert i done
        edges = g ! i
        (q', nodes') = foldl' (relax (i, cost)) (q, nodes) edges

    -- (v, w) は current の隣接ノードへの辺
    relax (current, currentCost) (q, nodes) (v, w) = (q', nodes')
      where
        cost = currentCost + w
        nodes' = IM.adjust (\x -> if cost < snd x then (current, cost) else x) v nodes
        q'
          | cost < snd (nodes IM.! v) = Heap.insert (Entry cost v) q
          | otherwise = q

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs
      result = dijkstra g n 1

  let vs = reverse $ takeWhile (/= (-1)) $ iterate (\i -> let (j, _) = result IM.! i in j) n
  putStrLn $ unwords $ map show vs
