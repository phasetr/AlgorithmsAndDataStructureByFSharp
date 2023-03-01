-- https://atcoder.jp/contests/tessoku-book/submissions/36401845
import Control.Monad (replicateM)
import Data.Array (Array, accumArray, array, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import qualified Data.IntSet as Set
import Data.List (unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

graph :: (Int, Int) -> [[Int]] -> Array Int [Int]
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs where
  xs = concatMap (\[u, v] -> [(u, v), (v, u)]) uvs

runDFS :: (Int -> [Int]) -> Int -> [(Int, Int)]
runDFS f v0 = reverse . fst $ dfs v0 ([(v0, -1 :: Int)], Set.singleton v0) where
  dfs :: Int -> ([(Int, Int)], Set.IntSet) -> ([(Int, Int)], Set.IntSet)
  dfs v (vs, visited) = foldr loop (vs, visited) (f v) where
    loop u (us, visited')
      | Set.member u visited' = (us, visited')
      | otherwise = dfs u ((u, v) : us, Set.insert u visited')

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs
      router = array (1, n) $ runDFS (g !) 1

  let simpleRoute = reverse $ takeWhile (/= -1) $ iterate (router !) n
  putStrLn $ unwords $ map show simpleRoute
