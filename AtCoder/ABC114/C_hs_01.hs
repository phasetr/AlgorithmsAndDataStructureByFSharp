-- https://atcoder.jp/contests/abc114/submissions/4563366
main :: IO ()
main = do
  n <- readLn
  print $ sum [1 | i<-[2..9], l<-mapM (const "753") [0..i], all (`elem` l) "753", read l < n+1]
