-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/1690188/satoshi3/Haskell
main :: IO ()
main = getContents >>=
  mapM_ (putStrLn . unwords . map show)
  . (\xs -> [x ++ [sum x] | x<-xs])
  . (\([r,c]:xs)
      -> xs ++ [[sum $ map (!!n) xs | n <- [0..c-1]]])
  . map (map read . words) . lines
