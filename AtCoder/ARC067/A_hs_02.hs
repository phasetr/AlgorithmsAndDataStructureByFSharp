-- https://atcoder.jp/contests/abc052/submissions/9155227
import Data.List ( foldl1', group, sort )

main :: IO ()
main = do
  n <- readLn :: IO Int
  print $ if n == 1 then 1 else cnt $ concat $ [factorize x | x<-[1..n]]

factorize :: Int -> [Int]
factorize 1 = []
factorize n = m : factorize (n `div` m) where
  [m] = take 1 [i | i <-[2..], n `mod` i == 0]

cnt :: [Int] -> Int
cnt [] = 0
cnt xs = foldl1' (\a b -> a*b `mod` (10^9+7)) . map ((+1) . length) . group $ sort xs
