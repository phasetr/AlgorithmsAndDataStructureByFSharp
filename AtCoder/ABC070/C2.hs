{-
https://atcoder.jp/contests/abc070/submissions/22268965
-}
import Control.Monad (replicateM)
import Data.List (foldl')

main :: IO ()
main = do
  n <- readLn
  ts <- replicateM n readLn :: IO [Int]
  print $ solve ts

solve :: [Int] -> Int
solve = foldl' lcm 1
