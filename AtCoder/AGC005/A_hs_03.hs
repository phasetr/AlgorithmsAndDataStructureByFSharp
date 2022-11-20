-- https://atcoder.jp/contests/agc005/submissions/13692043
main :: IO ()
main = do
  x <- getLine
  let (s,t) = foldl solve (0,0) x
  print $ s + t

solve :: (Int,Int) -> Char -> (Int,Int)
solve (s,t) x
  | x == 'S' = (s+1,t)
  | s == 0 = (s,t+1)
  | otherwise = (s-1,t)
