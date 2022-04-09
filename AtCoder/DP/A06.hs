-- https://atcoder.jp/contests/dp/submissions/26866015
main :: IO ()
main = do
  getLine
  h <- map read . words <$> getLine
  print $ last
    $ foldl (\[h2,c2,h1,c1] h0 -> [h1,c1,h0,min (c2 + abs(h0-h2)) $ c1 + abs(h0-h1)]) [0,0,head h,0] h
