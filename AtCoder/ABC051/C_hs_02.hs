-- https://atcoder.jp/contests/abc051/submissions/9848337
main :: IO ()
main = do
  [a,b,c,d] <- map read . words <$> getLine
  putStrLn $ f (c-a) (d-b) ++ "LULU" ++ f (c-a) (d-b)
f :: Int -> Int -> String
f x y = replicate y 'U' ++ replicate (x+1) 'R' ++ replicate (y+1) 'D' ++ replicate x 'L'
