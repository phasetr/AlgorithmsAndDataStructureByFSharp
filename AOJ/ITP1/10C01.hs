-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_10_C
main :: IO ()
main = do
  n <- readLn
  if n==0 then return () else do
    ss <- fmap (map read . words) getLine
    print $ solve n ss
    main
solve :: Double -> [Double] -> Double
solve n ss = sqrt $ sum (map (\s -> (s-m)**2) ss) / n
  where m = sum ss / n

test :: IO ()
test = do
  print $ near0 (solve 5 [70,80,100,90,20]) 27.85677655
  print $ near0 (solve 3 [80,80,80]) 0
  where near0 x y = abs (x-y) < 0.0001
