-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/2012136/earlgrey/Haskell
swap :: [Int] -> Int -> [Int]
swap xs i = take (i-1) xs ++ [xs!!i, xs!!(i-1)] ++ drop (i+1) xs

bubble :: Int -> [[Int]] -> [[Int]]
bubble n xss = foldl (\yss i -> let ys = head yss in if (ys !! i) < (ys !! (i - 1)) then swap ys i : yss else yss) xss [n - 1, n - 2 .. 1]

solve :: Int -> [Int] -> [[Int]]
solve n xs = loop [xs]
  where loop xss = let yss = bubble n xss in if length xss == length yss then xss else loop yss

main :: IO ()
main = do
  n  <- readLn
  xs <- fmap (map read . words) getLine
  let ls = solve n xs
  putStrLn $ unwords $ map show $ head ls
  print $ length ls - 1
