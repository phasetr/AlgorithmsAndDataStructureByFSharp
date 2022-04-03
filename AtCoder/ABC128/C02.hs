-- https://atcoder.jp/contests/abc128/submissions/24783427
import Control.Monad (replicateM)
import Data.List (subsequences)

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  kss <- map ( map read . words ) <$> replicateM m getLine
  ps <- map read . words <$> getLine
  print $ solve n kss ps

solve :: Int -> [[Int]] -> [Int] -> Int
solve n kss ps =
  length [os | os <- subsequences [1..n],
          all (isOnAt os) (zip kss ps)]
  where
    isOnAt os (_:ss, p) =
      length [s | s <- ss, s `elem` os] `mod` 2 == p
    isOnAt _ _ = error "undefined"
