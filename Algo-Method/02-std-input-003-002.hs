{-
https://algo-method.com/tasks/54
-}

main :: IO ()
main = getLine >> getLine >>= print . product . map read . words
