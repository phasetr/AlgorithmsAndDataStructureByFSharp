-- https://atcoder.jp/contests/abc127/submissions/17198156
import Control.Monad ( replicateM )
import Data.List ( sort, sortBy )

solve :: (Num a, Ord a) => [a] -> [[a]] -> [a]
solve [] _ = []
solve as [] = as
solve as ([0,_]:bcs) = solve as bcs
solve (a:as) bcs'@([b,c]:bcs)
  | a < c = c : solve as ([b-1,c]:bcs)
  | otherwise = a : solve as bcs'
solve _ _ = error "not come here"

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine :: IO [Int]
  as <- sort.map read . words <$> getLine :: IO [Int]
  bcss <- replicateM m (map read . words <$> getLine) :: IO [[Int]]
  print $ sum $ solve as $ sortBy (\a b -> compare (b!!1) (a!!1)) bcss
