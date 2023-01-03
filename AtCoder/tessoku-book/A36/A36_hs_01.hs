-- https://atcoder.jp/contests/tessoku-book/submissions/35448261
main :: IO ()
main = do
  li <- getLine
  let [n,k] = map read $ words li
  let ans = tba36 n k
  putStrLn $ if ans then "Yes" else "No"

tba36 :: Int -> Int -> Bool
tba36 n k = n2 <= k && even (k - n2)
  where n2 = 2 * pred n
