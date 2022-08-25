-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/3386207/tyanon/Haskell
{-# OPTIONS_GHC -Wall #-}
readInt :: String -> Int
readInt = read

binarySearch :: Int -> Int -> (Int -> Bool) -> Int
binarySearch lo hi f
  | lo+1 == hi = lo
  | otherwise  = if f mid then binarySearch mid hi f else binarySearch lo mid f
  where mid = (lo+hi) `div` 2

inf :: Int
inf = 1010000000000000000

isOk :: Int -> [Int] -> Int -> Int -> Bool
isOk _ [] _ _ = True
isOk 0 _ _ _  = False
isOk k xs@(w:ws) p r
  | w > r     = isOk (k-1) xs p p
  | otherwise = isOk k ws p (r-w)

solve :: Int -> [Int] -> Int
solve k ws = succ $ binarySearch 0 inf (not . isOk') where
  isOk' p = isOk k ws p p

main :: IO ()
main = do
  [_,k] <- fmap (map readInt . words) getLine
  ws <- fmap (map readInt . words) getContents
  print $ solve k ws
