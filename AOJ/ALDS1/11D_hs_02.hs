-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/3890730/niruneru/Haskell
import Control.Monad ( replicateM )
import Data.List (foldl')
import qualified Data.Vector as V
import qualified Data.Map as M

type Node      = Int
type Adjacency = [Int]
type AdjList   = V.Vector [Int]
type Query     = [Int]
type GID       = Int
type GIDs      = M.Map Int Int

main :: IO ()
main = do
  [n,c]   <- fmap (map read . words) getLine
  adjs    <- fmap (replicateM c $ map read . words) getLine
  q       <- readLn
  queries <- fmap (replicateM q $ map read . words) getLine
  mapM_ putStrLn $ answers n adjs queries

answers:: Int -> [Adjacency] -> [Query] -> [String]
answers n adjs = map ans where
  ans :: Query -> String
  ans [f, t]
    | groups M.! f == groups M.! t = "yes"
    | otherwise                    = "no"
  ans _ = error "not come here"

  groups :: GIDs
  groups = snd $ foldl' assign (1, M.empty) [0..n-1]

  adjList :: AdjList
  adjList = V.accum (flip (:)) (V.replicate n [])
            $ foldr (\[x, y] accum -> [(x, y), (y, x)] ++ accum) [] adjs

  assign :: (GID, GIDs) -> Node -> (GID, GIDs)
  assign (gid, gids) x
      | M.member x gids = (gid, gids)
      | otherwise       = (gid + 1, dfs gids x)
    where
      dfs :: GIDs -> Node -> GIDs
      dfs gids n
        | M.member n gids = gids
        | otherwise       = foldl' dfs (M.insert n gid gids) (adjList V.! n)
