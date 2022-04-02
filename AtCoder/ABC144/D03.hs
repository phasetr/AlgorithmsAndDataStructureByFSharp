-- https://atcoder.jp/contests/abc144/submissions/20349877
import Text.Printf (printf)
main :: IO ()
main = interact $ printf "%.7f" .
  solve . (\[a,b,x] -> (a,b,x)) . map read.words

solve :: (Double, Double, Double) -> Double
solve (a,b,x)
  | x > a*a*b/2 = f $ (a*a*b-x)*2/a^3
  | otherwise = f $ a*b^2 / (x*2)

f :: Double -> Double
f c = atan c*180/pi
