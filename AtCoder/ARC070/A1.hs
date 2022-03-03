{-
https://atcoder.jp/contests/abc056/submissions/23923922
-}
main :: IO ()
main = do
  n <- read <$> getLine
  print $ solve n

solve :: Int -> Int
solve n = head $ filter (\x -> x*(x+1) >= n*2) [1..]
