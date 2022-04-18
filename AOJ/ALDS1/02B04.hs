-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/3103721/little_Haskeller/Haskell
findMinimumIndex :: [Int] -> Int
findMinimumIndex [] = undefined
findMinimumIndex (x:xs) = (\(minj,_,_) -> minj)
  $ foldl f (0, 1, x) xs where
  f (minj,i,v) x = if x<v then (i,i+1,x) else (minj,i+1,v)

swapMinimum :: ([Int],Int) -> Int -> ([Int],Int)
swapMinimum (xs,c) i =
  if i>0 then (b:as++a:bs,c+1) else (xs,c)
  where (a:as, b:bs) = splitAt i xs

selectionSort :: [Int] -> ([Int],Int)
selectionSort xs = foldl f (xs,0) [0..length xs - 2] where
  f (xs,c) i = (as++ys, c') where
    (as,bs) = splitAt i xs
    (ys,c')  = swapMinimum (bs, c) $ findMinimumIndex bs

main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getLine
  let (ys, c) = selectionSort xs
  putStrLn $ unwords $ map show ys
  print c
