{-
https://algo-method.com/tasks/25
3 つの整数 A,B,C が空白区切りで入力されます。3 つの整数の平均値を整数で出力してください。

ただし、答えは整数になることが保証されています。
-}
main :: IO ()
main = getLine >>= putStrLn .show
  . (`div` 3) . sum . map read . words
