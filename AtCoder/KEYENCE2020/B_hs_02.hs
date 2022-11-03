-- https://atcoder.jp/contests/keyence2020/submissions/17215159
import qualified Data.List as List

main :: IO ()
main = do
  getLine
  contents <- lines <$> getContents
  let xls = map (map read.words) contents
  let intervals = List.sort [(x-l,x+l) | [x,l] <- xls]
  print $ remove (head intervals) (tail intervals) 1

remove :: (Ord a, Num t) => (a, a) -> [(a, a)] -> t -> t
remove _ [] k = k
remove (l1,r1) ((l2,r2):rest) k
  | r1 <= l2 = remove (l2,r2) rest (k+1)
  | r1 > l2 && r1 <= r2 = remove (l1,r1) rest k
  | otherwise = remove (l2,r2) rest k
