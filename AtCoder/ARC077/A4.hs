{-
https://atcoder.jp/contests/abc066/submissions/1434557
-}
solve :: [Int] -> [Int] -> [Int] -> [Int]
solve [] xs ys = ys ++ reverse xs
solve [x] xs ys = x:xs ++ reverse ys
solve (x:y:zs) xs ys = solve zs (x:xs) (y:ys)

main :: IO ()
main = do
  getLine
  as <- map read . words <$> getLine
  putStr . unwords . map show $ solve as [] []
