{-
https://atcoder.jp/contests/agc008/submissions/17717863
-}
main :: IO ()
main = do
  xy <- (\[x,y] -> (x,y)) . map read . words <$> getLine :: IO (Int,Int)
  print $ solve xy

solve :: (Ord a, Num a) => (a, a) -> a
solve (x,y)
  | abs x<=abs y = f x y
  | otherwise = g x y
f :: (Ord a, Num a) => a -> a -> a
f x y
  | x>=0 && y>=0 = y-x
  | x>=0 && y<0  = 1-y-x
  | x<0 && y>=0  = y+x+1
  | x<0 && y<0   = x-y+2
  | otherwise    = error "not come here"
g :: (Ord a, Num a) => a -> a -> a
g x y
  | x>=0 && y>0  = x-y+2
  | x>=0 && y<=0 = x+y+1
  | x<0 && y>0   = 1-x-y
  | x<0 && y<=0  = y-x
  | otherwise    = error "not come here"
