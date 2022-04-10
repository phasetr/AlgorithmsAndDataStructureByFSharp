-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/1696340/amusan39/Haskell
import Data.Char (isLower,isUpper,toLower,toUpper)
swapCase :: Char -> Char
swapCase c
  | isUpper c = toLower c
  | isLower c = toUpper c
  | otherwise = c
main :: IO ()
main = getLine >>= putStrLn . map swapCase
