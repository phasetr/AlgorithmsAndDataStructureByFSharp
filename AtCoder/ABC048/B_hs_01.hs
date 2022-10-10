-- https://atcoder.jp/contests/abc048/submissions/4762237
main :: IO ()
main = do
 [a,b,x] <- map read . words <$> getLine
 print $ b `div` x - (a-1) `div` x
