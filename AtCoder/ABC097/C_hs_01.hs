-- https://atcoder.jp/contests/abc097/submissions/26251817
import qualified Data.Set as IS

nub' :: [[Char]] -> [[Char]]
nub' = IS.toAscList . IS.fromList

main :: IO ()
main = do
  s <- getLine
  n <- readLn
  let ss = nub' $ concatMap ( substrs s ) [1..5]
  putStrLn $ ss !! (n-1)

substrs :: [a] -> Int -> [[a]]
substrs [] n = []
substrs all@(c:cs) n = take n all : substrs cs n
