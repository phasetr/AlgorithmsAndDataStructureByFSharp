{-
https://atcoder.jp/contests/agc015/submissions/1317554
-}
main :: IO ()
main = mapM_ (print . solve) . lines =<< getContents

solve :: [Char] -> Int
solve s = sum $ zipWith f [0..] s where
  n = length s
  f i 'U' = i*2+(n-1-i)
  f i 'D' = i+(n-1-i)*2
  f _ _ = error "Do not come here."

test :: IO ()
test = do
  print $ solve "UUD" == 7
  print $ solve "UUDUUDUD" == 77
