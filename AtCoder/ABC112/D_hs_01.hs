-- https://atcoder.jp/contests/abc112/submissions/17055073
main :: IO ()
main = print . solve . map read . words =<< getLine

solve :: Integral p => [p] -> p
solve [n,m] = div m . minimum . filter (n<=) $ f 1 m
solve _ = error "not come here"

f :: Integral a => a -> a -> [a]
f i k
  | i*i > k = []
  | r==0 = i:q:f (i+1) k
  | otherwise = f (i+1) k
  where (q,r) = k `divMod` i
