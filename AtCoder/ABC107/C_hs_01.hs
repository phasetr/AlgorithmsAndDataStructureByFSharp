-- https://atcoder.jp/contests/abc107/submissions/7355173
main :: IO ()
main = interact $ show . f . map read . words where
  f(_:k:l) = minimum . zipWith (%) l $ drop (k-1) l
  f _ = error "not come here"
  x%y | x>0 = y
      | y<0 = negate x
      | 0<1 = min(-x)y-x+y
      | otherwise = error "not come here"
