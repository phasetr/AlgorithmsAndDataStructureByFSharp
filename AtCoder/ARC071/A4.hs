{-
https://atcoder.jp/contests/abc058/submissions/15852937
-}
main :: IO ()
main = interact $ f . lines where
  f (_:l) = do
    c <- ['a'..'z']
    minimum [filter (==c) s | s <- l]
  f _ = error "undefined"
