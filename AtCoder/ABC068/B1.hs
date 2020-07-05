-- https://atcoder.jp/contests/abc068/submissions/5224609

main =
  interact $ \x -> show . (`div` 2) . head . dropWhile (((read::String->Int) x) >=) . map (2^) $ [1..]
