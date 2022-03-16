{-
https://atcoder.jp/contests/abc045/submissions/14204469
-}
import Data.Char (ord)

main :: IO ()
main = interact $ solve 0 . lines

solve :: Int -> [String] -> String
solve i abc
  | null $ abc!!i = ["ABC"!!i]
  | otherwise = solve k $ take i abc ++ tail (abc!!i) : drop (i+1) abc
  where k = subtract (ord 'a') . ord $ head (abc!!i)
