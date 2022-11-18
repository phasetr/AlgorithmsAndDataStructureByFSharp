-- https://atcoder.jp/contests/abc108/submissions/25689779
main :: IO ()
main = interact $ show . f . map read . words
f :: Integral a => [a] -> a
f [n,k] | even k = ((n+k `div` 2) `div` k)^3 + (n`div`k)^3 | 0<1 = (n `div` k)^3
f _ = error "not come here"
