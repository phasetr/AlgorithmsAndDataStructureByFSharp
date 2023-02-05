-- https://atcoder.jp/contests/tessoku-book/submissions/36784252
main :: IO ()
main = interact $ show . foldl1 ((+) . (2*)) . map (read . return) . filter ('0'<=)
