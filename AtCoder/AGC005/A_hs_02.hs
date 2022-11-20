-- https://atcoder.jp/contests/agc005/submissions/912035
--f :: Num a => [Char] -> [Char] -> a -> a
f :: String -> String -> Int -> Int
f [] _ n = n
f ('T':x) ('S':y) n = f x y (n-1)
f (c:x) y n = f x (c:y) (n+1)
main :: IO ()
main = do
  x <- getLine
  print $ f x [] 0
