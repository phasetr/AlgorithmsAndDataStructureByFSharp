-- https://atcoder.jp/contests/code-festival-2017-qualc/submissions/1706334
main :: IO ()
main = do
  s <- getLine
  print $ solve 0 s (reverse s)

solve :: Integral a => a -> [Char] -> [Char] -> a
solve n [] [] = div n 2
solve n (x:xs) []
  | x == 'x' = solve (n + 1) xs []
  | otherwise = -1
solve n [] (y:ys)
  | y == 'x' = solve (n + 1) [] ys
  | otherwise = -1
solve n (x:xs) (y:ys)
  | x == y = solve n xs ys
  | x == 'x' = solve (n + 1) xs (y:ys)
  | y == 'x' = solve (n + 1) (x:xs) ys
  | otherwise = -1
