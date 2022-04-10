-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1518935/hamukichi/Haskell
import Data.List (isInfixOf)

main :: IO ()
main = do
  s <- getLine
  p <- getLine
  putStrLn $ if isInfixOf p $ concat $ replicate 2 s then "Yes" else "No"
