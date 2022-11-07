-- https://atcoder.jp/contests/abc107/submissions/3075769
main :: IO ()
main = do
  [_, k] <- map read . words <$> getLine
  xs <- map read . words <$> getLine
  print $ solve k xs

solve :: Int -> [Int] -> Int
solve k xs = minimum $ zipWith (curry cost) (drop (k-1) xs) xs

cost :: (Int, Int) -> Int
cost (x, y) -- x > y
  | y < 0 && 0 < x = x - y + (x `min` (-y))
  | x <= 0 = -y
  | y >= 0 = x
  | otherwise = error "not come hee"
