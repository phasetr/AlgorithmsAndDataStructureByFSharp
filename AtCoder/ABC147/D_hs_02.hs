-- https://atcoder.jp/contests/abc147/submissions/15084303
import Data.Bits ( Bits((.&.)) )

main :: IO ()
main = do
  n <- read <$> getLine
  a <- map read . words <$> getLine
  print $ solve n a

solve :: Integer -> [Integer] -> Integer
solve n a = doit 1 where
  m = maximum a
  doit :: Integer -> Integer
  doit b
    | b > m     = 0
    | otherwise = ((b * count * (n - count)) + doit (b * 2)) `mod` 1000000007
    where count = fromIntegral $ length $ filter ((/= 0) . (.&. b)) a

