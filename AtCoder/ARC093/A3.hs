{-
https://atcoder.jp/contests/arc093/submissions/9847524
-}
main :: IO ()
main = do
  getLine
  aa <- map read . words <$> getLine
  let a = 0:(aa++[0])
  let b = zipWith f a$tail a
  let s = sum b
  let c = zipWith (+) b $ tail b
  let d = zipWith f a $ tail $ tail a
  putStr $ unlines [show (s+x-y) | (x,y) <- zip d c]
  where f x y = abs $ x-y
