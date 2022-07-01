main :: IO ()
main = getLine >>=
  putStrLn
  . (\[a, b, c] -> show . length $ filter ((==) 0 . mod c) [a..b])
  . map read . words
