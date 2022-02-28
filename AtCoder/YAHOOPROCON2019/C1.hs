import Data.Function ((&))
main :: IO()
main = do
  [k,a,b] <- map read . words <$> getLine :: IO [Int]
  print $ solve k a b

solve :: Int -> Int -> Int -> Int
solve k a b = if 2<b-a then (b-a)*d+m+a else k+1
  where (d,m) = (k+1-a) `divMod` 2
