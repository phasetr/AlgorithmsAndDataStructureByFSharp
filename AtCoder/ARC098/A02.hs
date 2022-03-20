{-
https://atcoder.jp/contests/arc098/submissions/2580496
-}
f :: Num a => a -> String -> [a]
f x [] = []
f x ('W':s) = x : f (x+1) s
f x ('E':s) = (x-1) : f (x-1) s
f _ _ = error "undefined"

main :: IO ()
main = do
  getLine
  s <- getLine
  let e = length $ filter (== 'E') s
  print $ minimum $ f e s
