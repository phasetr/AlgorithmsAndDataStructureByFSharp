-- https://atcoder.jp/contests/abc144/submissions/24978048
main :: IO ()
main = do
  [a,b,x] <- map read . words <$> getLine
  let r2d x = x * 180 / pi
  print $ if x <= a^2*b / 2
          then r2d $ atan (a * b^2 / 2 / x)
          else r2d $ atan $ 2 * (a^2 * b - x) / (a^3)
