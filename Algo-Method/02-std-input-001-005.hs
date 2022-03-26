{-
https://algo-method.com/tasks/23
0 以上 23 以下の整数 X が標準入力から与えられます。
現在の時刻が X 時のとき、日が変わる ( 24 時になる) まであと何時間かかるかを計算してください。
-}
main :: IO ()
main = getLine >>= putStrLn . show . (24-) . read
test1 = readLn >>= print . (24-)
