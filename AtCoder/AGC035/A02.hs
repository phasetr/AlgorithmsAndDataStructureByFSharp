{-
https://atcoder.jp/contests/agc035/submissions/7157227
-}
import Data.List (group,sort)
import Data.Bits (Bits(xor))
main :: IO ()
main = getLine >> getLine >>=
  print . solve . map read . words

solve :: [Int] -> String
solve xs = if b1 || b2 || b3 then "Yes" else "No" where
  xss = group $ sort xs
  l = length xss
  b1 = l==1 && head (head xss)==0
  b2 = l==2
       && head (head xss) == 0
       && length (head xss)*2 == length (xss!!1)
  b3 = l==3
       && length(head xss)==length(xss!!1)
       && length(xss!!1)==length(xss!!2)
       && head (head xss) `xor` head (xss!!1) `xor` head(xss!!2) == 0
