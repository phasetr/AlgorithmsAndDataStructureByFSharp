-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_7_D
import Control.Applicative ((<$>))
import Control.Monad (replicateM)
import Data.List (transpose,(!!))
main :: IO ()
main = do
  [n,m,l] <- map read . words <$> getLine
  a <- replicateM n (map read . words <$> getLine)
  b <- replicateM m (map read . words <$> getLine)
  mapM_ (putStrLn . unwords . map show) $ solve n m l a b
solve :: Int -> Int -> Int -> [[Int]] -> [[Int]] -> [[Int]]
solve n m l a b =
  map (\v -> map (sum . zipWith (*) v) bT) a
  where bT = transpose b

{-
mapM_ (putStrLn . unwords . map show) $ solve 3 2 3 [[1,2],[0,3],[4,5]] [[1,2,1],[0,3,2]]
mapM_ (putStrLn . unwords . map show) $ solve 3 2 3 [[1,2],[0,3],[4,5]] [[1,2,1],[0,3,2]] == [[1,8,5],[0,9,6],[4,23,14]]
-}
