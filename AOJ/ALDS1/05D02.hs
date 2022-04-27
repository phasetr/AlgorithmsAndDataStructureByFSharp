-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2543068/marta1127/Haskell
main :: IO ()
main = do
  n <- getLine
  as <- fmap (map read . words) getLine
  q <- getLine
  ms <- fmap (map read . words) getLine
  mapM_ (\m -> if solve m as then putStrLn "yes" else putStrLn "no" ) ms

solve :: (Ord a, Num a) => a -> [a] -> Bool
solve m [] = False
solve m (x:xs)
  | m == x    = True
  | m <  x    = solve m xs
  | otherwise = solve (m-x) xs || solve m xs
