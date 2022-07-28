-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_10_A
import Control.Applicative ((<$>))
main :: IO ()
main = do
  [x1,y1,x2,y2] <- map read . words  <$> getLine
  print $ solve x1 y1 x2 y2
solve :: Floating a => a -> a -> a -> a -> a
solve x1 y1 x2 y2 = sqrt ((x1-x2)^2 + (y1-y2)^2)
test = print $ near0 (solve 0 0 1 1) 1.41421356
  where near0 x y = abs (x-y) < 0.0001
