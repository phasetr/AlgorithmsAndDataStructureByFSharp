-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/2707227/satoshi3/Haskell
conv :: [[String]] -> [(String, Int)]
conv [] = []
conv ([a,b]:xs) = (a, read b) : conv xs
conv _ = undefined

solve :: Int -> [(String, Int)] -> [(String, Int)] -> Int -> IO()
solve _ [] [] _ = return ()
solve q [] buf time = solve q (reverse buf) [] time
solve q (all@(a,b):xs) buf time
  | (b - q) <= 0 = do
      putStrLn $ a ++ " " ++ (show . (time +)) b
      solve q xs buf (time + b)
  | otherwise = solve q xs ((a, b - q):buf) (time + q)

main :: IO ()
main = do
  ([_,qs]:xs) <- fmap (map words . lines) getContents
  solve (read qs) (conv xs) [] 0
