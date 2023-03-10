-- https://atcoder.jp/contests/tessoku-book/submissions/39578777
main :: IO ()
main = do
  n <- readLn
  print n
  putStr $ unlines $ map (unwords . map show) $ gen n
  where gen n = [[x,x+1] | x <- [1..n-1] ] ++ [[n,1]]
