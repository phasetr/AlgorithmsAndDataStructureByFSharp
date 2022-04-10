-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/1690442/satoshi3/Haskell
import Data.List (elemIndices)
import Data.Char (toLower)

main :: IO ()
main = getLine >>=
  mapM_ putStrLn
  . (\xs -> [ c : " : " ++ show (length $ elemIndices c xs) | c <- ['a'..'z']])
  . map toLower
