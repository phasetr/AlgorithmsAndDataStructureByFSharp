{-
https://atcoder.jp/contests/abc123/submissions/4871559
-}
main :: IO ()
main = do
  n <- readLn
  x <- minimum . map read . lines <$> getContents
  print $ (n+x-1) `div` x + 4
