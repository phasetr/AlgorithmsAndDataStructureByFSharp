-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_C&lang=ja
import Data.List ( sort )
solve :: [Int] -> String
solve = unwords . map show . sort
main :: IO ()
main = getLine >>= putStrLn . solve . map read . words

test :: IO ()
test = print $ solve [3,8,1] == "1 3 8"
