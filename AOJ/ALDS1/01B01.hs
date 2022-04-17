-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_B
main :: IO ()
main = getLine >>=
  print . (\[x,y] -> solve x y) . map read . words
solve :: Integral t => t -> t -> t
solve x y = if x<y then mygcd y x else mygcd x y where
  mygcd x y = if y==0 then x else mygcd y (x `mod` y)

test :: IO ()
test = do
  print $ 5 `div` 3
  print $ 5 `mod` 3
  print $ solve 147 105 == 21
