-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/2212417/aimy/Haskell
import Data.Char ( toLower )
main :: IO ()
main = getContents >>=
  (\(w:t) -> print $ length $ filter (==w) t)
  . words . map toLower
