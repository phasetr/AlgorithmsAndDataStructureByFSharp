{-
https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_10_B
三角形の２辺 a, b とその間の角 C から、
その三角形の面積 S、
周の長さ L, a を底辺としたときの高さ h を求めるプログラムを作成して下さい。
-}
main :: IO ()
main = do
  [a,b,cdeg] <- fmap (map read . words) getLine
  mapM_ print $ solve a b cdeg
solve :: Floating a => a -> a -> a -> [a]
solve a b cdeg = [(a*b*sin crad)/2,a+b+c,h] where
  c = sqrt ((a-b*cos crad)^2 + h^2)
  crad = cdeg*pi/180
  h = b * sin crad

test :: IO ()
test = do
  print $ zip (solve 4 3 90) [6.00000000,12.00000000,3.00000000]
  print $ zipWith (curry near0) (solve 4 3 90) [6.00000000,12.00000000,3.00000000]
  where near0 (x,y) = abs (x-y) < 0.0001
