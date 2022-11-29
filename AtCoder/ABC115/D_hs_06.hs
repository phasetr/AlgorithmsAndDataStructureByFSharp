-- https://atcoder.jp/contests/abc115/submissions/14245994
import Data.Array ( listArray, (!) )

main :: IO ()
main = do
  li <- getLine
  let [n,x] = map read $ words li
  let ans = compute n x
  print ans

{-
バーガーの厚さは、l0 = 1, ln = 2l(n-1)+3
肉の枚数は、m0 = 1, mn = 2m(n-1)+1
バーガーを素直に配列で作るのは無謀なので、計算で求める。
-}
la = listArray (0,50) $ iterate ((3 +).(2 *)) 1
ma = listArray (0,50) $ iterate (succ .(2 *)) 1

compute :: Int -> Int -> Int
compute = burger 0

-- n次元バーガーのx層を食べたときの肉の数 + a
burger a _ 0 = a
burger a n x
  | x <= n = a -- nバーガーの下n枚はバンズ
  | la ! n - x <= n = a + ma ! n -- nバーガーの上n枚はバンズ
  | ln1 >= x1 = burger a n1 x1 -- 下のn-1バーガーの中に納まる
  | x2 == 0   = m1 -- 真ん中の肉まで
  | otherwise = burger m1 n1 x2 -- ここまでと残り
  where
    x1 = pred x -- 一番下のバンズ
    n1 = pred n
    ln1 = la ! n1
    m1 = a + ma ! n1 + 1
    x2 = x1 - ln1 - 1
