-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/3393596/niruneru/Haskell
solve :: String -> Int
solve = head . foldl rpn [] . words where
  rpn (x:y:zs) "*" = y * x : zs
  rpn (x:y:zs) "-" = y - x : zs
  rpn (x:y:zs) "+" = y + x : zs
  rpn zs numstring = read numstring:zs
main :: IO ()
main = getLine >>= print . solve
