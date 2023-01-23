-- https://atcoder.jp/contests/tessoku-book/submissions/36372431
import Control.Monad (replicateM)
import Data.Array (Array, accumArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import qualified Data.IntSet as Set
import Data.List (unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

graph :: (Int, Int) -> [[Int]] -> Array Int [Int]
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs where
  xs = concatMap (\[u, v] -> [(u, v), (v, u)]) uvs

dfs :: (Int -> [Int]) -> Int -> [Int]
dfs f v0 = reverse . fst $ aux v0 ([v0], Set.singleton v0) where
  aux :: Int -> ([Int], Set.IntSet) -> ([Int], Set.IntSet)
  aux v (vs, visited) = foldr g (vs, visited) (f v) where
    g u (us, visited')
      | Set.member u visited' = (us, visited')
      | otherwise = aux u (u : us, Set.insert u visited')

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs

  putStrLn $
    if length (dfs (g !) 1) == n
      then "The graph is connected."
      else "The graph is not connected."

test = do
  let n = 3
  print $ graph (1,n) [[1,3],[2,3]]
