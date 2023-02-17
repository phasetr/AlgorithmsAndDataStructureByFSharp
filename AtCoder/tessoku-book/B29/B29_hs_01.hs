-- https://atcoder.jp/contests/tessoku-book/submissions/37930739
main :: IO ()
main = get >>= print . sol

get :: IO [Int]
get = map read . words <$> getLine

sol :: [Int] -> Int
sol (a:b:_) = pow a b
sol _ = error "not come here"

pow :: Integral t => Int -> t -> Int
pow a b
  | b == 0    = 1
  | odd b     = (a*r) `mod` m
  | otherwise = r
  where
    p = pow a (b `div` 2)
    r = (p*p) `mod` m
    m = 10^9+7
