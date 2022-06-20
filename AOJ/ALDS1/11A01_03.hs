-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/1687135/amusan39/Haskell
import Control.Monad ( replicateM_ )

main = do
  n <- readLn
  replicateM_ n $ do
    lines <- fmap (map read . drop 2 . words) getLine
    putStrLn $ unwords $ map (\a -> if a `elem` lines then "1" else "0") [1..n]
