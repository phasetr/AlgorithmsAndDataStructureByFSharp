{-
https://algo-method.com/tasks/24
2 つの正の整数 A,B が空白区切りで入力されます。A+B の値を出力してください。
-}
main :: IO ()
main = getLine >>= print . sum . map read . words
