{-
https://atcoder.jp/contests/abc089/submissions/26415960
-}
main :: IO ()
main = do
  n <- fmap (read::String -> Int) getLine
  ss <- fmap lines getContents
  print $ solve ss

solve ss = comb 3 $ map (count ss) "MARCH" where
  --count :: [String] -> Char -> Int
  count x a = length . filter (\(x:xs) -> x == a) $ x

  comb 0 _  = 1
  comb _ [] = 0
  comb n (x:xs)
    | length xs < n - 1 = 0
    | otherwise =  x * comb (n-1) xs + comb n xs
