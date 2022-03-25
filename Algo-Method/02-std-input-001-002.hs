{-
https://algo-method.com/tasks/16
1 以上 100 以下の整数 N が標準入力から与えられます。
N を 5 で割ったあまりを標準出力するプログラムを作成してください。
-}
main :: IO ()
main = getLine >>= print . (`div` 5) . read

test :: IO ()
test = do
  n <- read <$> getLine :: IO Int
  print $ n `div` 5
