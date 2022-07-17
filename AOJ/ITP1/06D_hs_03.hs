-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_D/review/1447866/yosh/Haskell
import Control.Monad (replicateM)
mul :: Num a => [[a]] -> [a] -> [a]
mul xs as = map (sum . zipWith (*) as) xs

main = do
   [n,m] <- map read . words <$> getLine
   matr <- replicateM n (map read . words <$>  getLine)
   v <- replicateM m readLn
   mapM_ print $ mul matr v
