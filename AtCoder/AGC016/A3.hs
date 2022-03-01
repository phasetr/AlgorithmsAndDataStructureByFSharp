{-
https://atcoder.jp/contests/agc016/submissions/9931821
-}
main :: IO ()
main = print . solve =<< getLine

solve :: String -> Int
solve s = minimum [f 0 c s | c<-['a'..'z']]

f :: Int -> Char -> String -> Int
f k c [] = k
f k c (d:s)
  | c==d = max k $ f 0 c s
  | c/=d = f (k+1) c s
f _ _ _ = 0
