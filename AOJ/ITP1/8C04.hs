-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/2376612/napo/Haskell
import Data.Char (toLower)
main :: IO ()
main = getContents >>=
  putStr . unlines . solve . map toLower
solve :: String -> [String]
solve s = map f ['a'..'z']
  where f c = (c : " : ") ++  (show . length $ filter (==c) s)
