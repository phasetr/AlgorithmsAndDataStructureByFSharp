{-
https://algo-method.com/tasks/32
文字列 S と正の整数 N が改行区切りで入力されます。S の前から N 番目の文字を出力してください。

ただしここでは、文字列 S の先頭の文字は 1 文字目であるとします。
-}
main :: IO ()
main = do
  s <- getLine
  n <- read <$> getLine :: IO Int
  putChar $ s!!(n-1)

main2 = getContents >>=
  putChar . (\[s,n] -> s!!(read n -1)) . lines
