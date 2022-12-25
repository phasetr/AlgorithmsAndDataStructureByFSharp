-- https://atcoder.jp/contests/agc003/submissions/14162863
main :: IO ()
main = do
  getLine
  as <- map read . words <$> getContents
  print . fst $ foldl f (0,0) as

f :: (Num a1, Eq a1, Integral a2) => (a2, a1) -> a2 -> (a2, a2)
f (p,0) k = let (d,m) = k `divMod` 2 in (p+d,m)
f (p,1) 0 = (p,0)
f (p,1) k = let (d,m) = (k-1) `divMod` 2 in (p+d+1,m)
f _ _ = error "not come here"
