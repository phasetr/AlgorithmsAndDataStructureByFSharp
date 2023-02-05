-- https://atcoder.jp/contests/tessoku-book/submissions/37972341
import Data.Bool ( bool )

main :: IO ()
main = do
  [a,b] <- map read . words <$> getLine
  let ans = any (\x -> gcd 100 x == x) [a..b]
  putStrLn $ bool "No" "Yes" ans
