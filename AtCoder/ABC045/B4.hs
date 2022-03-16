{-
https://atcoder.jp/contests/abc045/submissions/9705161
-}
main :: IO ()
main = getContents >>= putStrLn . solve . words
  --solve . words <$> getContents >>= putStrLn

solve :: [String] -> String
solve [a,b,c] = f 'a' a b c where
  f 'a' [] _ _ = "A"
  f 'b' _ [] _ = "B"
  f 'c' _ _ [] = "C"
  f 'a' (x:a) b c =  f x a b c
  f 'b' a (x:b) c =  f x a b c
  f 'c' a b (x:c) =  f x a b c
  f _ _ _ _ = error "not come here"
solve _ = error "not come here"

