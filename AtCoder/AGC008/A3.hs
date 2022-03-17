{-
https://atcoder.jp/contests/agc008/submissions/18942901
-}
main :: IO ()
main = do
  [x,y] <- map read . words <$> getLine
  print $ solve x y

solve :: (Num a, Ord a) => a -> a -> a
solve x y = abs (abs x - abs y) + f x y where
  f x y
    | x < 0 && 0 < y || 0 <= x && y < 0 || 0 < x && y <= 0 = 1
    | x <= y = 0
    | otherwise = 2
