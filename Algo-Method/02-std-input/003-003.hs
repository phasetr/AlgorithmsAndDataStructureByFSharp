{-
https://algo-method.com/tasks/52
-}
main :: IO ()
main = getLine >> getLine >>= mapM_ print
  <$> map (\x -> read x `mod` 10) . words
