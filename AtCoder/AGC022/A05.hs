{-
https://atcoder.jp/contests/agc022/submissions/3109728
-}
import Data.List ((\\),sort)

main :: IO ()
main = do
  s <- getLine
  putStrLn $ solve s

solve :: String -> String
solve s
  | length s == 26 = aux (reverse s) []
  | otherwise = s ++ [head $ ['a'..'z'] \\ s]
  where
    aux [] _ = show (-1)
    aux (c:cs) xs = if null f then aux cs (c:xs) else reverse $ head f : cs
      where f = sort $ filter (>c) xs
