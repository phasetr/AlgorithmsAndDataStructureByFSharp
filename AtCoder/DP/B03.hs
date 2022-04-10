-- https://atcoder.jp/contests/dp/submissions/26333726
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  hs <- map read . words <$> getLine
  print $ solve n k hs

solve :: Int -> Int -> [Int] -> Int
solve n k (h:hs) = loop [0] [h] hs where
  loop (c:_) _ [] = c
  loop cs ohs (h:hs) = loop (c:cs) (h:ohs) hs
    where
      c = minimum $ take k
          [c + abs (h-oh) | (c,oh) <- zip cs ohs]
  loop _ _ _ = undefined
solve _ _ _ = undefined
