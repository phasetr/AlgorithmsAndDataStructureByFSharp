-- https://atcoder.jp/contests/dp/submissions/26333135
main :: IO ()
main = do
  li <- getLine
  let n = read li
  li <- getLine
  let hs = map read $ words li
  let ans = compute n hs
  print ans

compute :: Int -> [Int] -> Int
compute n hs = loop 0 (abs (h1-h2)) h1 h2 h3s
  where (h1:h2:h3s) = hs

loop :: (Ord t, Num t) => t -> t -> t -> t -> [t] -> t
loop _  c2 _  _  []     = c2
loop c1 c2 h1 h2 (h:hs) = loop c2 c h2 h hs where
  c = min (c1 + abs (h1-h)) (c2 + abs (h2-h))
