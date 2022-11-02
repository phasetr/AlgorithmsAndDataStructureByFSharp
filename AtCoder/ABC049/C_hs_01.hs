-- https://atcoder.jp/contests/abc049/submissions/1024184
f :: [Char] -> [Bool]
f [] = [True]
f s = [a == x && or (f b) |
  x <- ["dream","dreamer","erase","eraser"],
  let (a,b) = splitAt (length x) s]
main :: IO ()
main = do
  s <- getLine
  putStrLn $ if or (f s) then "YES" else "NO"
