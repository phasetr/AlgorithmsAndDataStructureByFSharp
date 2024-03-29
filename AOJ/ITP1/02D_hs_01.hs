-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_D&lang=ja
main :: IO ()
main = getLine >>=
  putStrLn
  . (\xs -> solve (head xs) (xs!!1) (xs!!2) (xs!!3) (xs!!4))
  . map read . words

solve :: (Ord a, Num a) => a -> a -> a -> a -> a -> [Char]
solve w h x y r =
  if x - r >= 0 && y - r >= 0 && x + r <= w && y + r <= h
  then "Yes"
  else "No"
