-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_8_B
import Control.Applicative ((<$>))
import Data.Char (digitToInt)
main :: IO ()
main = do
  n <- getLine
  if n=="0" then return () else do
    print $ solve n
    main
solve :: String -> Int
solve = sum . map digitToInt

test :: IO ()
test = print $ solve "123" == 6
