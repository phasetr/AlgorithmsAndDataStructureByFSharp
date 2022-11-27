-- https://atcoder.jp/contests/code-festival-2016-quala/submissions/900931
a = fromEnum 'a'
z = fromEnum 'z'
f :: Int -> [Int] -> [Int]
f k [x] = [a+(x-a+k)`mod`(z-a+1)]
f k (x:xs)
  | x/=a && l>=0 = a : f l xs
  | otherwise = x : f k xs
  where l = k-(z-x+1)
f _ _ = error "not come here"
main :: IO ()
main = do
  s <- getLine
  k <- fmap read getLine
  putStrLn $ map toEnum $ f k $ map fromEnum s
