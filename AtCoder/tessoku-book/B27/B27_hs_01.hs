-- https://atcoder.jp/contests/tessoku-book/submissions/35370501
main :: IO ()
main = getLine >>= print . (\(a:b:_) -> lcm a b) . map read . words
