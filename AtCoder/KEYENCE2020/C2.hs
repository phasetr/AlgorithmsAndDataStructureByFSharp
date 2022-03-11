{-
https://atcoder.jp/contests/keyence2020/submissions/15311353
-}
main :: IO ()
main = interact $ solve . map read . words

solve :: [Int] -> String
solve [n,k,s] = unwords . map show
  $ replicate k s ++ replicate (n-k) ((s+1) `mod` 10^9)
solve _ = error "not come here"
