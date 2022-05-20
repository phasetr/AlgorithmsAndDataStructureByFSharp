-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/1690448/satoshi3/Haskell
import Data.List ( elemIndices )
import Data.Char ( toLower )

main :: IO ()
main = getContents >>= print
  . (\(x:xs) -> length $ elemIndices x xs)
  . map (map toLower) . words
