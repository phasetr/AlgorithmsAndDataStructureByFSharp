-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/2376818/napo/Haskell
main :: IO ()
main = getContents
  >>= putStrLn . unwords . map show
  . foldl1 (zipWith (+)) . map (f . words) . tail . lines
f :: (Ord a1, Num a2) => [a1] -> [a2]
f (x:y:_) | x > y  = [3,0]
          | x < y  = [0,3]
          | x == y = [1,1]
f _ = undefined
