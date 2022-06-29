main :: IO ()
main = readLn >>=
  putStrLn .
  foldl1 (\x y -> x ++ ":" ++ y) .
  map show .
  (\s -> [s `div` 3600, s `div` 60 `mod` 60, s `mod` 60])
