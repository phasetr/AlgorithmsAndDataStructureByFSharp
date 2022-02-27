-- https://atcoder.jp/contests/abc116/submissions/10737716
main :: IO()
main = do
  getLine
  hn <- map read . words <$> getLine
  print $ solve hn

solve :: (Ord a, Num a) => [a] -> a
solve hn =
  foldl (\ans (prev, next) -> if prev < next then ans+next-prev else ans) 0 $ zip (0:init hn) hn
