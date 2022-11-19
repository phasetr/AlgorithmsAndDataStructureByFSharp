intToNString :: Int -> Int -> String
intToNString n x
  | n == 0 = []
  | n == 1 = replicate x '1'
  | n <= 16 = getNString x n
  | otherwise = []
  where
    getNString :: Int -> Int -> String
    getNString x n
      | x == 0 = []
      | otherwise = getNString (x `div` n) n ++ (numbers !! (x `mod` n))
      where numbers = ["0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"]

-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_C
-- 素数判定
isPrime :: Integral a => a -> Bool
isPrime x = (x/=1) && all (\n -> x `mod` n /= 0) (takeWhile (\y -> y*y <= x) [2..])

-- GCD, https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_B
mygcd :: Integral t => t -> t -> t
mygcd x y = if x<y then f y x else f x y where
  f x y = if y==0 then x else f y (x `mod` y)

main :: IO ()
main = do
  print $ 5 `div` 3 == 1
  print $ 5 `mod` 3 == 2
  print $ map (intToNString 2) [1,2,3,4,5,9,10] == ["1","10","11","100","101","1001","1010"]
  print $ mygcd 147 105 == 21
  print $ all (\n -> 1 `mod` n /= 0) []
  print $ filter isPrime [1..10] == [2,3,5,7]
