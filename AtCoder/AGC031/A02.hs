{-
https://atcoder.jp/contests/agc031/submissions/13928890
-}
import Data.List (foldl',group,sort)
main :: IO ()
main = do
  getLine
  s <- getLine
  print $ solve s

solve :: String -> Int
solve s = pred . foldl' (\a x -> (a*x) `mod` 1000000007) 1
  $ map (succ . length) (group (sort s))
