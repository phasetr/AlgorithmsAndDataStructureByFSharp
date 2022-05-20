-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_9_B
import Control.Monad (replicateM)
main :: IO ()
main = do
  s <- getLine
  if s=="-" then return () else do
    n <- readLn
    hs <- replicateM n readLn
    putStrLn $ solve s hs
    main

solve :: String -> [Int] -> String
solve = foldl (\t h -> drop h t ++ take h t)

test :: IO ()
test = do
  print $ solve "aabc" [1,2,1] == "aabc"
  print $ solve "vwxyz" [3,4] == "xyzvw"
