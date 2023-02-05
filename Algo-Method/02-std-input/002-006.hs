{-
https://algo-method.com/tasks/29
4 つの正の整数 A,B,C,D が空白区切りで入力されます。4 つの整数の最大値を出力してください。
-}
main :: IO ()
main = getLine >>= print . maximum . map (\x -> read x :: Int) . words
