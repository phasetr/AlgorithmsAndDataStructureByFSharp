{-
https://atcoder.jp/contests/abc066/submissions/1398254
-}
solve :: [a] -> [a] -> [a] -> [a]
solve xs ys [] = ys ++ reverse xs
solve xs ys (z:zs) = solve ys (z:xs) zs

main :: IO ()
main = do
  getLine
  as <- getLine
  putStrLn $ unwords $ solve [] [] $ words as
