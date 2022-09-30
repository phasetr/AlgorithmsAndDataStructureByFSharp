-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/1906193/Naoki_M/Haskell
import Data.Int ( Int64 )
main :: IO ()
main = getContents >>= print . foldl lcm 1 . map (read :: String -> Int64) . words . last . lines
