{-
https://atcoder.jp/contests/abc067/submissions/15314990
-}
main :: IO ()
main = interact $ show . solve . map read . words

solve :: (Ord t, Num t) => [t] -> t
solve (n:a:as) = f (abs (a-t)) a t as where
  t = sum as
  f s _ _ [_] = s
  f s l r (a:as) = f (min s $ abs (l-r+2*a)) (l+a) (r-a) as
  f _ _ _ _ = error "not come here"
solve _ = error "not come here"
