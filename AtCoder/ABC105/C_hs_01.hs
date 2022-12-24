-- https://atcoder.jp/contests/abc105/submissions/9848463
main :: IO ()
main = do
  n <- readLn
  putStrLn $ if n==0 then "0" else f n

f :: (Integral a, Show a) => a -> [Char]
f 0 = ""
f k = f ((k `mod` 2-k) `div` 2) ++ show (k `mod` 2)
