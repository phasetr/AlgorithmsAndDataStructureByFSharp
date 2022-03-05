{-
https://atcoder.jp/contests/cf17-final/submissions/19672215
-}
import Data.List (group,sort)

-- 全ての差を取らずに最大値と最小値の差を見ている
solve :: String -> String
solve s = if f s then "YES" else "NO" where
  f [_] = True
  f [a, b] = a /= b
  f s = length c == 3 && maximum c - minimum c <= 1
    where c = map length (group (sort s))

main :: IO ()
main = do
  s <- getLine
  putStrLn $ solve s

test :: IO ()
test = do
  print $ solve "abac" == "YES"
    && solve "aba" == "NO"
    && solve "babacccabab" == "YES"
