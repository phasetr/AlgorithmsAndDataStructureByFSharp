-- https://atcoder.jp/contests/abc080/submissions/12061359
import Control.Monad ( replicateM )

solve :: (Ord a1, Eq a2, Num a2, Num a1) => p -> [[a2]] -> [[a1]] -> a1
solve n f' p = maximum $ map calc $ replicateM 10 [False,True] where
  calc op
    | or op = sum $ zipWith (cal op) f p
    | otherwise = -(10^10)
  cal op f = (!! length (filter id (zipWith (&&) op f)))
  f = map (map (== 1)) f'

main :: IO ()
main = do
  n <- readLn
  f <- replicateM n (map read . words <$> getLine)
  p <- replicateM n (map read . words <$> getLine)
  print $ solve n f p
