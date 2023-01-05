-- https://atcoder.jp/contests/tessoku-book/submissions/35453133
main :: IO ()
main = do
  getLine
  s <- getLine
  let ans = or $ zipWith3 f s (tail s) (drop 2 s)

  putStrLn $ if ans then "Yes" else "No"

f a b c = a == b && b == c
