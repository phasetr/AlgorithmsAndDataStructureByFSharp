-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_10_D
main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getLine
  ys <- fmap (map read . words) getLine
  mapM_ print (solve xs ys)

solve :: (Ord a, Floating a) => [a] -> [a] -> [a]
solve xs ys = [l1,l2,l3,linf]
  where
    l1 = sum $ zipWith (\x y -> abs(x-y)) xs ys
    l2 = sqrt $ sum $ zipWith (\x y -> abs(x-y)**2) xs ys
    l3 = sum (zipWith (\x y -> abs(x-y)**3) xs ys)**(1/3)
    linf = maximum $ zipWith (\x y -> abs(x-y)) xs ys

test :: IO ()
test = do
  print $ zipWith (curry near0) (solve [1,2,3] [2,0,4]) [4.000000,2.449490,2.154435,2.000000]
  where near0 (x,y) = abs(x-y) < 0.00001
