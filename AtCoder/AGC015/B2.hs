{-
https://atcoder.jp/contests/agc015/submissions/13264070
-}
solve s = foldl count 0 zs
  where
    zs = zip [1..] s
    l = length zs
    count zs (f,b)
      | b == 'U' = zs + (l-f) + 2*(f-1)
      | b == 'D' = zs + 2*(l-f) + (f-1)
      | otherwise = error "Do not come here"

main :: IO ()
main = do
    s <- getLine
    print $ solve s

test :: IO ()
test = do
  print $ solve "UUD" == 7
  print $ solve "UUDUUDUD" == 77
