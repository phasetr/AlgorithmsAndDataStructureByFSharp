-- https://atcoder.jp/contests/abc114/submissions/35006257
main :: IO ()
main = readLn >>= print . abc114c

abc114c :: Int -> Int
abc114c n = length $ filter valid $ takeWhile (n >=) xs where
  xs = 0 : concatMap f xs
  f x = map (x * 10 +) [3,5,7]

valid :: Show a => a -> Bool
valid x = all (`elem` s) "357" where s = show x

-- はまやん方式で全生成
