-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/2766932/R_S/Haskell
main :: IO ()
main = interact
  $ (++ "\n") . unwords . map show
  . (\(ts,hs) -> [sum ts, sum hs])
  . unzip . map (score . (\[t,h] -> (t,h)) . words) . tail . lines

score :: (String,String) -> (Int,Int)
score (t,h) = case compare t h of
  GT -> (3,0)
  EQ -> (1,1)
  LT -> (0,3)
