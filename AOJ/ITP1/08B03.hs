-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/1690385/satoshi3/Haskell
import Data.Char ( digitToInt )
main :: IO ()
main = getContents >>=
  mapM_ (print . sum . map digitToInt) . init . words
