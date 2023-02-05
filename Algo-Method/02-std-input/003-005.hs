{-
https://algo-method.com/tasks/57
-}
main :: IO ()
main = getLine >> getLine >>= mapM_ putStrLn <$> reverse . words
