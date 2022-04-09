-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/16469728
main :: IO ()
main = getLine >>=
  putStr . solve . (\[n,m,k] -> (n,m,k)) . map read . words

solve :: (Num a, Enum a, Eq a) => (a, a, a) -> [Char]
solve (n,m,k) =
  if null [True | i <- [0..n], j <- [0..m],
            i*(m-j)+j*(n-i) == k]
  then "No" else "Yes"
