{-
https://atcoder.jp/contests/agc022/submissions/19299067
-}
import Data.List ((\\),sort)

bigc :: Char -> [Char] -> String
bigc a str = sort (filter (>a) str)

nexts :: String -> String -> String
nexts [] _ = "-1"
nexts (a:b) str =
  if null c then nexts b (a:str) else reverse (head c : b)
  where c = bigc a str

solve :: String -> String
solve s =
  if length s == 26 then nexts (reverse s) ""
  else s ++ [head (['a'..'z'] \\ s)]

main :: IO ()
main = interact solve -- getLine >>= print . solve
