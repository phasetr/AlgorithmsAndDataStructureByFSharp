{-
https://atcoder.jp/contests/agc017/submissions/19724026
-}
main :: IO ()
main = do
  [n, p] <- map read . words <$> getLine
  xs <- map read . words <$> getLine
  print $ solve n p xs

solve :: Integral p => p -> p -> [p] -> p
solve n p xs =
  case (iseven, p == 0) of
    (True, True) -> 2^n
    (True, False) -> 0
    _ -> 2^(n-1)
  where iseven = all even xs

test :: IO ()
test = print $ solve 2 0 [1,3] == 2
  && solve 1 1 [50] == 0
  && solve 3 0 [1,1,1] == 4
  && solve 45 1 [17,55,85,55,74,20,90,67,40,70,39,89,91,50,16,24,14,43,24,66,25,9,89,71,41,16,53,13,61,15,85,72,62,67,42,26,36,66,4,87,59,91,4,25,26] == 17592186044416
