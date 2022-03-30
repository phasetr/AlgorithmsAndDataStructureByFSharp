-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_6_D
import Control.Applicative ((<$>))
import Control.Monad (replicateM)
main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  a <- replicateM n (map read . words <$> getLine)
  b <- map read <$> replicateM m getLine
  putStr $ unlines $ map show $ solve a b
solve :: Num b => [[b]] -> [b] -> [b]
solve a b = map (sum . zipWith (*) b) a

-- solve 3 4 [[1,2,0,1],[0,3,0,1],[4,1,1,0]] [1,2,3,0]
