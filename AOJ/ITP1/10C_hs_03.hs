-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/2213538/aimy/Haskell
main = interact $ unlines . map (show . solve) . read' . lines
  where read' xs = case xs of {["0"] -> []; (n:ss:xs') -> (read n, map read (words ss)) : read' xs'}

solve (n,ss) = sqrt $ sum (map (\s -> (s - med ss)^2) ss) / fromIntegral n
  where med ss = sum ss / fromIntegral n
