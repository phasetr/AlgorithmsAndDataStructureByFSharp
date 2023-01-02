-- https://atcoder.jp/contests/tessoku-book/submissions/35371224
import Data.List ( foldl' )

tba29 :: Int -> Int -> Int
tba29 = powerish mul 1

mul :: Int -> Int -> Int
mul x y = mod (x * y) modBase
modBase :: Int
modBase = 10^9 + 7

-- @gotoki_no_joe
powerish :: Integral a1 => (a2 -> a2 -> a2) -> a2 -> a2 -> a1 -> a2
powerish mul i a b = foldl' {-'-} mul i [p | (True, p) <- zip bs ps] where
  bs = map odd $ takeWhile (0 <) $ iterate (`div` 2) b
  ps = iterate (\x -> mul x x) a

main :: IO ()
main = do
  [a,b] <- getLnInts
  let ans = tba29 a b
  print ans

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine
