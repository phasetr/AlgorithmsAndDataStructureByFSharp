-- https://atcoder.jp/contests/diverta2019-2/submissions/12060912
import Data.List ( group, sort )
import Control.Monad ( replicateM )

solve :: (Num a, Num b, Ord a, Ord b) => Int -> [(a, b)] -> Int
solve n xy = n - m where
  m = maximum . (0:) . map length . group $ sort difs
  difs = [(a-x, b-y) | p@(a,b)<-xy, q@(x,y)<-xy, p/=q]

main :: IO ()
main = do
  n <- readLn
  xy <- replicateM n read2
  print $ solve n xy

read2 :: IO (Integer, Integer)
read2 = (\[a,b] -> (a,b)) <$> readWords
readWords :: IO [Integer]
readWords = map read . words <$> getLine
