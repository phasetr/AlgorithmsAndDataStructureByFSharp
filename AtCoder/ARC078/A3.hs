{-
https://atcoder.jp/contests/abc067/submissions/16470460
-}
main :: IO ()
main =interact $ show . f . map read . words

f :: (Ord p, Num p) => [p] -> p
f (_:x:l) = minimum . map abs
  $ zipWith (-) (scanl (+) x l) $ scanr1 (+) l
f _ = error "not come here"
