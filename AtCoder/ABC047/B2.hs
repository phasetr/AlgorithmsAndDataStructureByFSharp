{-
https://atcoder.jp/contests/abc047/submissions/14441584
-}
main :: IO ()
main = print . solve
  . map (map read . words) . lines =<< getContents

solve :: (Num a, Ord a) => [[a]] -> a
solve ([w,h,_]:xyas) = g $ foldr f (0,w,0,h) xyas where
  f [x,_,1] (w1,w2,h1,h2) = (max x w1,w2,h1,h2)
  f [x,_,2] (w1,w2,h1,h2) = (w1,min x w2,h1,h2)
  f [_,y,3] (w1,w2,h1,h2) = (w1,w2,max y h1,h2)
  f [_,y,4] (w1,w2,h1,h2) = (w1,w2,h1,min y h2)
  f _ _ = error "not come here"
  g (w1,w2,h1,h2) = max (w2-w1) 0 * max (h2-h1) 0
solve _ = error "not come here"
