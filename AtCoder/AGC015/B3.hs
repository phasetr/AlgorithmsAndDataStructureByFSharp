{-
https://atcoder.jp/contests/agc015/submissions/3124612
-}
solve :: [Char] -> Int
solve s =
  sum [if i == 1 || i == n then n-1
       else if si == 'U' then (i-1)*2+n-i else (n-i)*2+i-1
      | (i,si) <- zip [1..] s]
  where n = length s

main :: IO ()
main = print . solve =<< getLine

test :: IO ()
test = do
  print $ solve "UUD" == 7
  print $ solve "UUDUUDUD" == 77
