-- https://atcoder.jp/contests/abc071/submissions/1529153
main :: IO ()
main = do
  getLine
  s <- getLine
  print . g 1 $ f s

f :: (Num a1, Eq a2) => [a2] -> [a1]
f [] = []
f [x] = [1]
f (x:y:zs)
  | x == y = 0 : f zs
  | otherwise = 1 : f (y:zs)

g :: (Integral a1, Num a2, Eq a2) => a1 -> [a2] -> a1
g p [0] = p %*% 6
g p [1] = p %*% 3
g p (0:0:zs) = g (p %*% 3) (0:zs)
g p (0:1:zs) = g (p %*% 2) (1:zs)
g p (1:0:zs) = g p (0:zs)
g p (1:1:zs) = g (p %*% 2) (1:zs)
g p _ = error "not come here"

(%*%) :: Integral a => a -> a -> a
(%*%) x y = x * y `mod` 1000000007
