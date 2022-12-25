-- https://atcoder.jp/contests/tessoku-book/submissions/35758121
readIntsLn :: IO [Int]
readIntsLn = fmap read . words <$> getLine

main :: IO ()
main = do
  [n, k] <- readIntsLn
  ps <- readIntsLn
  qs <- readIntsLn
  putStrLn $ if k `elem` ((+) <$> ps <*> qs) then "Yes" else "No"
