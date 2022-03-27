-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_4_D
import Text.Printf
main :: IO ()
main = getLine >> getLine >>=
  (\xs -> printf "%d %d %d\n" (minimum xs) (maximum xs) (sum xs))
  . map (read :: String -> Int) . words
