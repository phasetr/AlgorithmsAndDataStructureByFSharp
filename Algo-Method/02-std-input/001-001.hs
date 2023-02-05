{-
https://algo-method.com/tasks/15
1 以上 100 以下の整数 N が標準入力から与えられます。
N を 2 倍した値を標準出力するプログラムを作ってください。
-}
module Main where
main :: IO ()
main = do
  n <- read <$> getLine :: IO Int
  print $ n*2
