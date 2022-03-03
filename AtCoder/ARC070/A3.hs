{-
https://atcoder.jp/contests/abc056/submissions/11401993
-}
main :: IO ()
main = print . ceiling . (\x -> (sqrt(8*x+1)-1)/2) =<< readLn
