-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_B/review/1448008/yosh/Haskell
solve :: [(Int,Int)] -> IO ()
solve [] = return ()
solve ((0,0):_) = return ()
solve ((n,x):r) = do
  print . length $
      [(i,j,k) | i <- [1..n], j <- [i+1..x-i],
                  let k = x-i-j, j < k && k <= n]
  solve r

main :: IO ()
main =
  getContents >>=
  solve
  . map ( (\[x,y] -> (x,y)) . map read . words) . lines
