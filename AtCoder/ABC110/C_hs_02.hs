-- https://atcoder.jp/contests/abc110/submissions/4585938
import Data.List ( sort )

elemCount :: Eq a => [a] -> [Int]
elemCount [] = []
elemCount (x:xs) = length (filter (== x) xs) + 1 : elemCount (filter (/= x) xs)

main::IO()
main = do
  a <- getLine
  b <- getLine
  putStrLn$ if sort (elemCount a) == sort (elemCount b) then "Yes" else "No"
