-- https://atcoder.jp/contests/abc110/submissions/12928553
import Data.List ( group, sort )

main :: IO ()
main = do
  s <- getLine
  t <- getLine
  putStrLn $ if sort (f (sort s)) == sort (f (sort t)) then "Yes" else "No"
  where f s = map length (group s)
