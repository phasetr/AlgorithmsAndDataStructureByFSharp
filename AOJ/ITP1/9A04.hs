-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/1696361/amusan39/Haskell
import Data.List ( elemIndices )
import Data.Char ( toLower )

solve :: [String] -> Int
solve (w:t) = length $ elemIndices (map toLower w) (map (map toLower) t)
solve _ = undefined

main :: IO ()
main = getContents >>= print . solve . init . words
