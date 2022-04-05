-- https://atcoder.jp/contests/abc129/submissions/22356083
import Control.Monad (replicateM)
import Data.List (foldl')
import qualified Data.IntSet as S

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  as <- replicateM m readLn
  print $ solve n as

solve :: Int -> [Int] -> Int
solve n as = fst $ foldl' f (1,0) [1..n]
  where
    aset = S.fromDistinctAscList as
    f (x,y) k
      | k `S.member` aset = (0, x)
      | otherwise         = (x %+% y, x)
    x %+% y = (x + y) `mod` 1000000007
