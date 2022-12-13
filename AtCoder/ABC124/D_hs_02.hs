-- https://atcoder.jp/contests/abc124/submissions/4996672
main :: IO ()
main = do
  [n,k] <- map (read :: String -> Int) . words <$> getLine
  bs <- app <$> getLine
  print $ ans (2*k+1) bs

ans :: Int -> (Int, [Int]) -> Int
ans k (n,bs) = if k > n then head bs else func bs (drop k bs) where
  func (a:xs) [p] = a-p
  func (a:_:xs) (p:_:ys) = max (a-p) $ func xs ys
  func _ _ = error "not come here"

app :: String -> (Int, [Int])
app bs = finfunc $ foldl func ('1',0,1,[0]) bs where
  finfunc (c,n,l,ns) = if c == '0' then (l+2,n:n:ns) else (l+1,n:ns)
  func (c,n,l,ns) k
    | c == k = (c,n+1,l,ns)
    | otherwise = (k,n+1,l+1,n:ns)
