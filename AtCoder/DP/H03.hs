-- https://atcoder.jp/contests/dp/submissions/26866276
main=do
  getLine
  a <- lines <$> getContents
  print $ solve a

solve :: (Foldable t, Integral a) => t [Char] -> a
solve a = last $ foldl (\t ai -> tail $ scanl (\x (y,aij) -> if aij=='.' then mod(x+y) $ 10^9+7 else 0) 0 $ zip t ai) (1:repeat 0) a
