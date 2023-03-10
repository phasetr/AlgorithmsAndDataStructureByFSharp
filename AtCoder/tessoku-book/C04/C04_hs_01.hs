-- https://atcoder.jp/contests/tessoku-book/submissions/39558442
import qualified Data.IntSet as IS
import Data.List ( sort )
nub' :: [IS.Key] -> [IS.Key]
main :: IO ()
nub' = IS.toAscList . IS.fromList
main = do
  n <- readLn
  let lim = ceiling $ sqrt $ fromIntegral n
  let candidates = sort $ nub' $ concat [ [x,y] | x <- [1..lim], n `mod` x == 0, let y = n `div` x ]
  putStr $ unlines $ map show candidates
