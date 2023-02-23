-- https://atcoder.jp/contests/tessoku-book/submissions/35453234
main :: IO ()
main = do
  li <- getLine
  let ans = tbb41 $ map read $ words li
  print $ length ans
  mapM_ (putStrLn . unwords . map show) ans

tbb41 :: [Int] -> [[Int]]
tbb41 = reverse . takeWhile ([1,1] /=) . iterate step

step :: (Ord a, Num a) => [a] -> [a]
step [x,y]
  | x > y = [x - y, y]
  | otherwise  = [x, y - x]
step _ = error "not come here"
