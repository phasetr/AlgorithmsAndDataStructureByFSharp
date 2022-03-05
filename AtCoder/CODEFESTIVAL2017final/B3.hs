{-
https://atcoder.jp/contests/cf17-final/submissions/12938734
-}
main :: IO ()
main = do
  s <- getLine
  putStrLn $ solve s

-- 全ての個数が [n/3, n/3 + 1] にあるかをチェックする.
solve :: String -> String
solve s = if bl then "YES" else "NO" where
  n = length s
  a = length $ filter (== 'a') s
  b = length $ filter (== 'b') s
  c = n - a - b
  bl = all (\i -> n `div` 3 <= i && i <= n `div` 3 + 1) [a,b,c]

test :: IO ()
test = do
  print $ solve "abac" == "YES"
    && solve "aba" == "NO"
    && solve "babacccabab" == "YES"
