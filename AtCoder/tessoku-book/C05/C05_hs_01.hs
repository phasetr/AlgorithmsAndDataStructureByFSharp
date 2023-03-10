-- https://atcoder.jp/contests/tessoku-book/submissions/39558607
import Numeric ( showIntAtBase )
import Data.Char ( intToDigit )
main :: IO ()
main = do
  n <- readLn
  putStrLn $ fill $ map replace $ showIntAtBase 2 intToDigit (pred n) "" -- 123を2進数表記

replace :: Char -> Char
replace '0' = '4'
replace '1' = '7'

fill :: [Char] -> [Char]
fill s = replicate (10 - length s) '4' ++ s
