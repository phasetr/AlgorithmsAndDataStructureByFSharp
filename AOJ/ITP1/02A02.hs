main :: IO ()
main = do
  [a, b] <- map (read :: String -> Int) . words <$> getLine
  putStrLn $ if a < b then "a < b" else if a > b then "a > b" else "a == b"
