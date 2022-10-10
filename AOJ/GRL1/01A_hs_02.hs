-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/2410330/aimy/Haskell
import qualified Data.ByteString.Char8 as B
import Data.List ( foldl', groupBy, sort )
import Data.IntMap ((!))
import qualified Data.IntMap as M
import Data.Maybe ( fromJust )
import qualified Data.Set as S
import qualified Data.Tuple as T
import Data.Bifunctor ( Bifunctor(second) )

addToSet :: (Foldable t, Ord b, Ord a) => S.Set (b, a) -> t (a, b) -> S.Set (b, a)
addToSet = foldl' (\ acc x -> S.insert (T.swap x) acc)

addToMap :: Foldable t => M.IntMap a -> t (M.Key, a) -> M.IntMap a
addToMap = foldl' (\ acc (x, d) -> M.insert x d acc)

dijkstra :: (Ord a, Num a) => M.IntMap [(M.Key, a)] -> M.Key -> M.IntMap a
dijkstra graph source = dijkstra' graph (S.singleton (0, source)) (M.singleton source 0)

dijkstra' :: (Ord a, Num a) => M.IntMap [(M.Key, a)] -> S.Set (a, M.Key) -> M.IntMap a -> M.IntMap a
dijkstra' graph pq res
  | S.null pq = res
  | otherwise = dijkstra' graph (addToSet pq' info) (addToMap res info)
  where
    fwd = M.findWithDefault
    ((dis, node), pq') = S.deleteFindMin pq
    nodes = fwd [] node graph
    update = filter (\ (x, e) -> M.notMember x res || dis + e < res!x) nodes
    info = map (second (dis +)) update
--    info = map (\ (x, e) -> (x, dis + e)) update

buildGraph :: [(M.Key, a, b)] -> M.IntMap [(a, b)]
buildGraph edges =
 let g = groupBy (\ (x, _, _) (y, _, _) -> x == y) edges
 in M.fromDistinctAscList (map (\ x -> (f1 $ head x, map (\ (_, y, z) -> (y, z)) x)) g)

readInt :: B.ByteString -> Int
readInt = fst . fromJust . B.readInt
f1 :: (a, b, c) -> a
f1 (x, _, _) = x
f3 :: (a, b, c) -> c
f3 (_, _, x) = x

main :: IO ()
main = do
  ((nv,_,r):edges) <- fmap (map ((\[x,y,z]->(x,y,z)) . map readInt . B.words) . B.lines) B.getContents
  let g = buildGraph (sort edges)
  let res = dijkstra g r
  mapM_ (putStrLn . maybe "INF" show . flip M.lookup res) [0..nv-1]
