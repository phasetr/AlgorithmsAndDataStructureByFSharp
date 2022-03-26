{-
https://algo-method.com/tasks/22
長さ 5 の文字列 S が標準入力から与えられます。文字列 S の中央の文字を出力してください。

たとえば入出力例 1 に示す通り、S= power に対しては、文字 w を出力します。
-}
main :: IO ()
main = getLine >>= putChar . (!!2)

test1 = (!!2) <$> getLine >>= putChar
test2 = getLine >>= putChar . head . drop 2
test3 = interact $ return . (!!2)
