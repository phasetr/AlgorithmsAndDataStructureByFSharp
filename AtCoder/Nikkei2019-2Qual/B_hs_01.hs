-- https://atcoder.jp/contests/nikkei2019-2-qual/submissions/9944003
import Data.List ( sort )
mo = 998244353 :: Integer
main :: IO ()
main = do
 getLine
 d <- map read . words <$> getLine
 let c = f 0 0 $ sort d
 print $ if head d/=0 || head c/=1 then 0 else foldl1 (\a b -> a*b `mod` mo) $ zipWith power c $ tail c
power :: Integer -> Integer -> Integer
power a n
 | n==0 = 1
 | even n = power (a*a `mod` mo) (div n 2)
 | odd n = a * power a (n-1) `mod` mo
 | otherwise = error "not come here"
f :: Integer -> Integer -> [Integer] -> [Integer]
f i c [] = [c]
f i c (d:ds)
 | i == d = f i(c+1)ds
 | i /= d = c:f (i+1) 0 (d:ds)
 | otherwise = error "not come here"
