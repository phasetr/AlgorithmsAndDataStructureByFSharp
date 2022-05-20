-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/2211476/aimy/Haskell
main :: IO ()
main = interact
  $ unlines . map (show . sum . map (read . return))
  . takeWhile (/= "0") . lines
