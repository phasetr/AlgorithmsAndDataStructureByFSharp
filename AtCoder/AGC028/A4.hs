{-
https://atcoder.jp/contests/agc028/submissions/9129020
-}
import qualified Data.IntMap as M

solve :: Int -> Int -> String -> String -> Int
solve n m s t = if all (==True) $ M.elems xx then l else -1 where
  l = lcm n m
  ss = M.fromList $ zip (ids n) s
  tt = M.fromList $ zip (ids m) t
  ids k = 1 : [l `div` k * i  + 1 | i <- [1..]]
  xx = M.intersectionWith (==) ss tt

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine :: IO [Int]
  [s,t] <- lines <$> getContents
  print $ solve n m s t
