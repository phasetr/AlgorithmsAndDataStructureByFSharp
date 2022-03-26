{-
https://algo-method.com/tasks/56
-}
main :: IO ()
main = getLine >> getLine >>= mapM_ print
  . filter (\x -> x `mod` 3 == 0) . map read . words
