-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/3094870/little_Haskeller/Haskell
bubbleSort :: [Int] -> (Int ,[Int])
bubbleSort xs = loop (1, 0, xs) where
  n = length xs - 2
  loop (0, m, xs) = (m, xs)
  loop (1, m, xs) = loop $ foldr f (0, m, xs) [0 .. n]
  loop _ = undefined
  f i  (f, m, xs) = if b > c
                    then (1, m + 1, as ++ c : b : ds)
                    else (f, m, as ++ bs)
    where (as, bs@(b : c : ds)) = splitAt i xs

main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getLine
  let (m, ys) = bubbleSort xs
  putStrLn $ unwords $ map show ys
  print m

test = do
  print $ bubbleSort [5,3,2,4,1] == (8,[1,2,3,4,5])
  print $ bubbleSort [5,2,4,6,1,3] == (9,[1,2,3,4,5,6])
