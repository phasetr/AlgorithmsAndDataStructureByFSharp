-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/1694879/satoshi3/Haskell
import Data.List (transpose)

split :: Int -> [Int] -> [[Int]]
split _ [] = []
split n x = take n x : split n (drop n x)

main :: IO ()
main = getContents >>=
  mapM_ (putStrLn . unwords . map show)
  . (\([f,s,t]:xs) -> split t $ [sum $ zipWith (*) x y | x <- take f xs, y <- transpose $ drop f xs])
  . map (map read . words) . lines
