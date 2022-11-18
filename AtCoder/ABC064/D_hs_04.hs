-- https://atcoder.jp/contests/abc064/submissions/1359310
f :: (Eq a1, Num a1, Num a2) => (a1, a2) -> Char -> (a1, a2)
f (x,y) '(' = (x+1,y)
f (x,y) _
  | x == 0 = (x,y+1)
  | otherwise = (x-1,y)
main :: IO ()
main = do
  getLine
  s <- getLine
  let (x,y) = foldl f (0,0) s
  putStrLn $ replicate y '(' ++ s ++ replicate x ')'
