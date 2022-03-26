{-
https://algo-method.com/tasks/27
2 つの正の整数 A,B が空白区切りで入力されます。A と B のうち大きい方の値を出力してください。

ただし、A と B の値は異なることが保証されています。
-}
main :: IO ()
main = getLine >>= print
  . (\[a,b] -> if a `mod` 10 < b `mod` 10 then a else b)
  . map read . words
