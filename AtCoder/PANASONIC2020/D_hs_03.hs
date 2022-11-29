-- https://atcoder.jp/contests/panasonic2020/submissions/15870304
main = do
  n <- read <$> getLine :: IO Int
  mapM (putStrLn.reverse) (solve n)

solve :: Int -> [String]
solve 1 = ["a"]
solve n = [c:cs | cs <- solve (n-1),c <- ['a'..succ $ maximum cs],c <= 'z']
