-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/3386071/tyanon/Haskell
solve :: [Int] -> Int
solve a = maximum b where
  b    = zipWith (-) (tail a) mins
  mins = scanl1 min a

main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getContents
  print $ solve xs

test = do
  print $ solve [6,5,3,1,3,4,3] == 3
  print $ solve [3,4,3,2] == 1
