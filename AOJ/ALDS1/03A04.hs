-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/2536995/napo/Haskell
import Data.List ( foldl' )

main :: IO()
main = getLine >>= print . solveRPN . words

solveRPN :: [String] -> Int
solveRPN = head . foldl' f [] where
  f (x:y:ys) "+" = (y + x) : ys
  f (x:y:ys) "-" = (y - x) : ys
  f (x:y:ys) "*" = (y * x) : ys
  f xs        n  = read n  : xs
