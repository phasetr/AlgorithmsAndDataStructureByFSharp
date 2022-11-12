-- https://atcoder.jp/contests/abc133/submissions/24844014
main :: IO ()
main = do
  n  <- readLn
  as <- map read . words <$> getLine
  putStrLn . unwords . map show $ solve n as

solve :: Int -> [Int] -> [Int]
solve n as = scanl (\acc x -> 2*x - acc) x1 $ take (n-1) as
  where x1 = sum $ zipWith (*) as (cycle [1,-1])
