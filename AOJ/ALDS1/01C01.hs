-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_C
main :: IO ()
main = getLine >> getContents >>=
  print . solve . map read . lines
solve :: [Integer] -> Int
solve = length . filter isPrime where
  isPrime x = all (\n -> x `mod` n /= 0) $ takeWhile (\y -> y*y <= x) [2..]
test :: IO ()
test = do
  print $ takeWhile (\y -> y*y <= 4) [2..]
  print $ all (\n -> 4 `mod` n /= 0) $ takeWhile (\y -> y*y <= 4) [2..]
  print $ solve [2,3,4,5,6,7]
  print $ solve [2,3,4,5,6,7] == 4
