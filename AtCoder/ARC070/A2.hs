{-
https://atcoder.jp/contests/abc056/submissions/12966703
-}
solve :: Int -> Int
solve n = length . takeWhile (< n) $ scanl (+) 0 [1..]

main :: IO ()
main = do
  n <- readLn
  print $ solve n
