-- https://atcoder.jp/contests/abc112/submissions/3417651
solver :: Int->Int->Int
solver m n =
  maximum
  . concatMap (\i -> filter (\j -> j*n <= m) [div m i,i])
  . filter (\i -> mod m i ==0)
  . takeWhile (\i -> i^2 <= m) $ [1..]

main::IO()
main = do
  [n,m] <- map read . words <$> getLine
  print (solver m n)
