-- https://atcoder.jp/contests/tessoku-book/submissions/35448175
main :: IO ()
main = do
  n <- readLn
  li <- getLine
  let as = map read $ words li
  let ans = tba35 n as
  print ans

tba35 :: Int -> [Int] -> Int
tba35 n as = ans where
  [ans] = foldl step as $ reverse $ take (pred n) $ cycle [max,min]
  step as f = zipWith f as $ tail as
