{-
https://atcoder.jp/contests/abc130/submissions/24784722
-}
main :: IO ()
main = do
  [w,h,x,y] <- map read. words <$> getLine
  putStrLn $ (\(a,b) -> show a ++ " " ++ show b) $ solve w h x y

solve :: Int -> Int -> Int -> Int -> (Double, Int)
solve w h x y = (fromIntegral (w*h) * 0.5 :: Double, if x * 2 == w && y * 2 == h then 1 else 0)

test :: IO ()
test = do
  print $ solve 2 3 1 2 == (3.000000, 0)
  print $ solve 2 2 1 1 == (2.000000, 1)
