{-
https://atcoder.jp/contests/agc035/submissions/6371774
-}
import Data.Bits (Bits(xor))

main :: IO ()
main = getLine >> getLine >>= putStrLn . solve
  . map read . words

solve :: [Int] -> String
solve as = if foldl1 xor as == 0 then "Yes" else "No"
