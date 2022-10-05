{-
https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_4_C
-}
main :: IO ()
main = do
  [a,b,c] <- words <$> getLine
  if b=="?" then return () else do
    print $ calc (read a) b (read c)
    main

calc :: Int -> String -> Int -> Int
calc x "+" y = x+y
calc x "-" y = x-y
calc x "*" y = x*y
calc x "/" y = x `div` y
calc _ _ _ = error "undefined"
