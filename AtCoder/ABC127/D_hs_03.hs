-- https://atcoder.jp/contests/abc127/submissions/24744678
import Control.Monad ( replicateM )
import Data.List ( foldl', sort, sortOn )
import Data.Ord ( Down(Down) )

main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  cards <- sort . map read . words <$> getLine
  reads <- replicateM m $ map read . words <$> getLine
  let xs = sort' $ concat $ sortOn Down (map reverse reads)
  print $ foldl' (+) 0 (func xs cards)

sort' :: [Int] -> [Int]
sort' [] = []
sort' (b:a:xs) = replicate a b ++ sort' xs
sort' _ = error "not come here"

func :: [Int] -> [Int] -> [Int]
func xs = zipWith max (xs ++ repeat 0)
