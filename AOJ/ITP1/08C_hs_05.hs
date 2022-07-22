-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/2459097/lhttjdr/Haskell
import Data.Char (toLower)
main :: IO ()
main = getContents >>= putStr . unlines . solve
solve :: String -> [String]
solve s = map f ['a'..'z'] where
  f c = c : " : " ++ show (length $ filter (== c) lowered)
  lowered = map toLower s
