{-
https://atcoder.jp/contests/arc059/submissions/1550300
-}
main :: IO ()
main = do
  getLine
  as <- map read . words <$> getLine
  print $ minimum [sum [(a-x)^2 | a <- as] | x <- [-100..100]]
