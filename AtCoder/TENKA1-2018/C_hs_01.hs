-- https://atcoder.jp/contests/tenka1-2018/submissions/3527492
import Control.Monad ( replicateM )
import Data.List ( sort )

pattern :: Int -> [[Int]]
pattern n
  | even n = let h = div n 2 in [replicate (h-1) (-2) ++ [-1, 1] ++ replicate (h-1) 2]
  | otherwise = let h = div n 2 in [replicate (h-1) (-2) ++ [-1, -1] ++ replicate h 2, replicate h (-2) ++ [1, 1] ++ replicate (h-1) 2]

f :: Int -> [Int] -> Int
f n cs = maximum $ map (sum . zipWith (*) cs) (pattern n)

main :: IO ()
main = readLn >>= \n -> replicateM n readLn >>= print . f n . sort
