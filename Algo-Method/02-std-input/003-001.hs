{-
https://algo-method.com/tasks/53
N 個の正の整数 A0,A1,…,AN−1が与えられます。
N 個の整数の合計値を求めてください。
-}
main :: IO ()
main = getLine >> getLine >>= print . sum . map read . words
