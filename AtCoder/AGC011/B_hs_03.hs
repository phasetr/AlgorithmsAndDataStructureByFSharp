-- https://atcoder.jp/contests/agc011/submissions/14150373
import Data.List ( sortBy )
sortDesc :: [Int] -> [Int]
sortDesc = sortBy (flip compare)

main :: IO()
main = do
  n <- readLn :: IO Int
  xs <- map read . words <$> getLine :: IO [Int]
  print $ solve $ sortDesc xs

solve :: [Int] -> Int
solve a = loop (sum a) a 1 where
  loop total [] ans = ans
  loop total (x:xs) ans
    | x > (total - x) * 2 = ans
    | otherwise = loop (total - x) xs (ans + 1)
