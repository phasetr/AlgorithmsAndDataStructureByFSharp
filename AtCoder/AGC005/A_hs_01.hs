-- https://atcoder.jp/contests/agc005/submissions/9931696
main :: IO ()
main = getLine >>= print . foldl (\a c -> max (a + if c=='S' then 2 else -2) 0) 0
