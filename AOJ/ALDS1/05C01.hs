-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_5_C
main :: IO()
main = p (0,0) >> readLn >>= koch (0,0) (100,0) >> p (100,0)

koch :: (Float,Float) -> (Float,Float) -> Int -> IO ()
koch _ _  0 = return ()
koch left@(x1,y1) right@(x2,y2) n =
  koch left s (n-1) >> p s >> koch s u (n-1) >> p u >> koch u t (n-1) >> p t >> koch t right (n-1)
  where
    s1 = (2*x1 + x2) / 3
    s2 = (2*y1 + y2) / 3
    s = (s1,s2)
    t1 = (x1 + 2 * x2) / 3
    t2 = (y1 + 2 * y2) / 3
    t = (t1,t2)
    piOverThree = pi/3
    u = ((t1-s1)*cos piOverThree - (t2-s2)*sin piOverThree + s1,
          (t1-s1)*sin piOverThree + (t2-s2)*cos piOverThree + s2)

p :: (Float,Float) -> IO()
p (x,y) = putStrLn $ show x ++ " " ++ show y
