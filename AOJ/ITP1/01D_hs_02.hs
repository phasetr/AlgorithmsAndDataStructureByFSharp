main :: IO ()
main = do
  s <- readLn :: IO Int
  putStrLn $ foldl1 (\x y -> x ++ ":" ++ y) $ map show [s `div` 3600, s `div` 60 `mod` 60, s `mod` 60]
