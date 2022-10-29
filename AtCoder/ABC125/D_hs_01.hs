-- https://atcoder.jp/contests/abc125/submissions/9712662
import Data.List ( sort )
main :: IO ()
main = do
 n <- getLine
 a <- map read . words <$> getLine
 print $ sum $
   if even (length (filter (<0) a)) then map abs a
   else (\(l:a) -> (-1*l):a) (sort (map abs a))
