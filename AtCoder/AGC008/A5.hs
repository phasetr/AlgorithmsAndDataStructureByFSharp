{-
https://atcoder.jp/contests/agc008/submissions/9931736
-}
main :: IO ()
main = do
  [a,b] <- map read . words <$> getLine
  print $ (+1) $ minimum $ abs <$> [a+b,b-a-1]
