-- https://atcoder.jp/contests/abc048/submissions/26794378
main :: IO ()
main = interact $ show . f . map read . words; f [a,b,x] = div b x - div (a-1) x
