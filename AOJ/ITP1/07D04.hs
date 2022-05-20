-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/1696335/amusan39/Haskell
import Control.Monad
import Control.Applicative
import Data.List

printMatrix :: [[Integer]] -> IO ()
printMatrix = mapM_ (putStrLn . unwords . map show)

main :: IO ()
main = do
  [n, m, l] <- map read . words <$> getLine
  a <- replicateM n $ map read . words <$> getLine
  b <- replicateM m $ map read . words <$> getLine
  printMatrix $ [[sum (zipWith (*) a' b') | b' <- transpose b ] | a' <- a]
