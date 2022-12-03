-- https://atcoder.jp/contests/abc099/submissions/8243833
import Data.List ( nub )
main :: IO ()
main = do
 n <- readLn
 print $ g [n]

maxpower :: Int -> Int -> Int
maxpower n x
  | x<n = 1
  | otherwise = n * maxpower n (x `div` n)

f :: [Int] -> [Int]
f [] = []
f (x:xs) = nub $ (x - maxpower 6 x ) : (x - maxpower 9 x) : f xs

g :: [Int]->Int
g xs
  | 0 `elem` xs =0
  | otherwise = g (f xs) + 1
