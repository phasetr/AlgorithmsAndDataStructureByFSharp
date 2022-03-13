{-
https://atcoder.jp/contests/abc158/submissions/20648184
-}
main :: IO ()
main = putStrLn . solve . words =<< getContents

solve :: [String] -> String
solve (s:q:qs) = f s [] $ map head qs where
  f a b ('1':qs) = f b a qs
  f a b ('2':'1':c:qs) = f (c:a) b qs
  f a b ('2':'2':c:qs) = f a (c:b) qs
  f a b [] = a ++ reverse b
  f _ _ _ = undefined
solve _ = undefined
