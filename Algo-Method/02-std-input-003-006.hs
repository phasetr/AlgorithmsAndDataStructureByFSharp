{-
https://algo-method.com/tasks/60
-}
main :: IO ()
main = do
  n <- readLn
  as <- map read . words <$> getLine
  print $ (\x -> floor $ x/n :: Int) $ sum as

solve :: IO ()
solve =  do
  n <- readLn :: IO Int
  xs <- map read . words <$> getLine :: IO [Int]
  print $ sum xs `div` n
