-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/1518989/hamukichi/Haskell
import Data.List
import Control.Applicative

solve :: [String] -> [Int]
solve [t,h]
  | t > h  = [3, 0]
  | t == h = [1, 1]
  | t < h  = [0, 3]
solve _ = undefined

main :: IO ()
main = do
  _ <- getLine
  getContents >>=
    putStrLn . unwords . map (show . sum) . transpose . map (solve . words) . lines
