-- https://atcoder.jp/contests/abc141/submissions/7970076
import Control.Monad
import qualified Data.IntMap as M

main :: IO ()
main = do
  (n:m:as) <- map read . words <$> getContents
  print $ solve n m as

solve :: Int -> Int -> [Int] -> Int
solve n m as = go mp0 m where
  mp0 = foldr (\a mp -> M.insertWith (+) a 1 mp) M.empty as

  go mp 0 = M.foldrWithKey (\k v acc -> k * v + acc) 0 mp
  go mp m = go mp1 (m - 1) where
    mp1 = case M.findMax mp of
      (k, 1) -> M.insertWith (+) (k `div` 2) 1 $ M.delete k mp
      (k, _) -> M.insertWith (+) (k `div` 2) 1 $ M.adjust pred k mp
