-- https://atcoder.jp/contests/abc121/submissions/4521830
import Foreign ( Bits(xor) )
main :: IO ()
main = interact $ show. f . (\[a,b] -> (a,b)) . map read . words where
  f (a,b) = g b `xor` g(a-1)
    where g x = [x,1,x+1,0] !! mod x 4
