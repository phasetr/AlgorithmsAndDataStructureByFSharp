{-
https://atcoder.jp/contests/abc123/submissions/25840682
-}
main :: IO ()
main = interact $ show . f . map read . words where
  f (n:l) | m <- minimum l = div (n+m-1) m+4
  f _ = error "not come here"
