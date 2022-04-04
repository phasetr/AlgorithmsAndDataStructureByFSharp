-- https://atcoder.jp/contests/abc061/submissions/18064784
import Data.List (sortBy)
import Control.Monad (replicateM)

main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  abs <- replicateM n (map read . words <$> getLine)
  print $ solve k abs

solve :: Int -> [[Int]] -> Int
solve k abs =
  calc $ sortBy (\[a1, _] [a2, _] -> compare a1 a2) abs
  where
    calc :: [[Int]] -> Int
    calc ([ha,hb]:xs) = fst
      $ foldl (\(t,acc) [a,b] ->
                  if acc >= k then (t, acc)
                  else (a, acc + b)) (ha, hb) xs
    calc _ = error "undefined"
