-- https://atcoder.jp/contests/abc051/submissions/14684395
main :: IO ()
main = interact $ solve .map read . words
solve :: [Int] -> String
solve [sx,sy,tx,ty] =
  concat $ zipWith replicate [x,y+1,x+1,y+1,1,1,x+1,y+1,x+1,y] "RULDRDRULD"
  where (x,y) = (tx-sx,ty-sy)
solve _ = error "not come here"
