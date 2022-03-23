{-
https://atcoder.jp/contests/abc047/submissions/21601143
-}
import Data.List (group)

main :: IO ()
main = do
  s <- getLine
  print $ solve s
solve :: String -> Int
solve s = length (map head $ group s) - 1
