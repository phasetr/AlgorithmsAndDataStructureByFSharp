-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3064890/utopian/Haskell
import Control.Monad ( join, replicateM, forM_ )
import Data.List ( minimumBy )
import qualified Data.Map.Strict as Map

main :: IO ()
main = do
  n <- readLn
  am <- replicateM n $ fmap (map read . words) getLine
  forM_ (Map.toList . solve . toAdjList $ am) (\(node, distance) -> putStrLn $ show node ++ " " ++ show distance)

type Node = Int
type Weight = Int
type AdjList = [Map.Map Node Weight]

toAdjList :: [[Int]] -> [Map.Map Node Weight]
toAdjList [] = []
toAdjList (a:as) = adjacents a:toAdjList as where
  adjacents :: [Int] -> Map.Map Node Weight
  adjacents (i:n:bs) = Map.fromList $ toPair bs
  adjacents _ = error "not come here"
  toPair :: [Int] -> [(Node, Weight)]
  toPair [] = []
  toPair (x:y:zs) = (x, y):toPair zs
  toPair _ = error "not come here"

solve :: AdjList -> Map.Map Node Int
solve al = dijkstra al $ Map.singleton 0 0 where
  dijkstra :: AdjList -> Map.Map Node Int -> Map.Map Node Int
  dijkstra al ss
    | length al <= Map.size ss = ss
    | otherwise = dijkstra al $ Map.insert i d ss
    where
      adjacents = join [[(j, ss Map.! i + (al !! i) Map.! j) | j <- Map.keys (al !! i), j `notElem` Map.keys ss]
                       | i <- [0..(length al - 1)], i `elem` Map.keys ss]
      (i, d) = minimumBy (\x y -> compare (snd x) (snd y)) adjacents
