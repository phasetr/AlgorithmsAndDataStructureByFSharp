-- https://atcoder.jp/contests/abc114/submissions/23840640
main :: IO ()
main = do
  n <- readLn :: IO Int
  print $ solve n

solve :: Int -> Int
solve n = length
  $ takeWhile (<=n)
  $ filter (\i -> let i' = show i in all (`elem` i') "357") $ go []

go :: Num a => [a] -> [a]
go [] = go [3,5,7]
go xs = xs ++ go [10*x+y|x<-xs, y <- [3,5,7]]
