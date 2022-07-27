-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/1690581/satoshi3/Haskell
main :: IO ()
main = getContents
  >>= putStrLn
  . (\x -> shows (sum $ fst x) " " ++ show (sum $ snd x))
  . (\xs -> unzip [ if a > b then (3,0) else if a < b then (0,3) else (1,1) | [a,b] <- xs])
  . map words . tail . lines
