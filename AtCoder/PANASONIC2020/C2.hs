{-
https://atcoder.jp/contests/panasonic2020/submissions/21754836
-}
main :: IO ()
main = do
  [a,b,c] <- map read . words <$> getLine
  putStrLn $ solve a b c

solve :: Int -> Int -> Int -> String
solve a b c = if 0<d && (4*a*b < d^2) then "Yes" else "No"
  where d = c-a-b
