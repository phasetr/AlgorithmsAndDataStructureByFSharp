{-
https://atcoder.jp/contests/abc065/submissions/14420043
-}
main :: IO ()
main = interact $ show . solve . map read . words

solve :: [Int] -> Int
solve [n,m] = if abs (n-m) > 1 then 0
  else f n @*@ f m @*@ if n==m then 2 else 1
solve _ = error "undefined"

f :: Int -> Int
f x = foldl1 (@*@) [1..x]

mnum :: Int
mnum = 10^9+7

infixl 7 @*@
(@*@) :: Int -> Int -> Int
(@*@) a b = a*b `mod` mnum
