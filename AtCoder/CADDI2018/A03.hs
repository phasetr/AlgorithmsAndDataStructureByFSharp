-- https://atcoder.jp/contests/caddi2018/submissions/9944877
main :: IO ()
main = do
  [n,p] <- map read . words <$> getLine
  let a = f 0 2 p
  print $ product $ map (\(u,v) -> u^div v n) a

f :: (Integral a, Num b, Eq b) => b -> a -> a -> [(a, b)]
f c i p
  | p `mod` i == 0 = f (c+1) i (div p i)
  | c /= 0 = (i,c):f 0 (i+1) p
  | i*i > p = [(p,1)]
  | otherwise = (i,c):f 0 (i+1) p
