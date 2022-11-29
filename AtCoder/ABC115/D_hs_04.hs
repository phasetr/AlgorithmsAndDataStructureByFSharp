-- https://atcoder.jp/contests/abc115/submissions/11644801
main = getLine >>= print . (\[n,x] -> f n x) . map read . words
f n = g sz pt where
  sz = iterate ((+3).(*2)) 1 !! n
  pt = iterate ((+1).(*2)) 1 !! n
g _ _ 0 = 0
g 1 _ _ = 1
g sz pt k
  | k <= psz+1 = g psz ppt (k-1)
  | k <= sz-2  = ppt + 1 + g psz ppt (k-psz-2)
  | otherwise  = pt
  where
    psz = div (sz-3) 2
    ppt = div (pt-1) 2
