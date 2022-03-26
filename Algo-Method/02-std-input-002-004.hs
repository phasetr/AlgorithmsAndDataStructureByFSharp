{-
https://algo-method.com/tasks/28
2 つの正の整数 A,B が空白区切りで入力されます。A が B の倍数かどうかを判定してください。
-}
main :: IO ()
main = getLine >>= putStr
  . (\[a,b] -> if a `mod` b == 0 then "Yes" else "No")
  . map read . words
