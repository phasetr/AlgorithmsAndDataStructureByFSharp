-- https://atcoder.jp/contests/cf16-final/submissions/12966831
import Data.List (partition)

main = do
  n <- readLn
  let (ts, ds) = partition (< n) $ scanl (+) 0 [1..n]
  let l = length ts
      m = head ds - n
  mapM_ print [1..m-1]
  mapM_ print [m+1..l]
