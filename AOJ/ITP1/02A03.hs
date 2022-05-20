main :: IO ()
main = getLine >>= putStrLn . solve . map read . words
solve :: [Int] -> String
solve [a, b]
  | a > b  = "a > b"
  | a < b  = "a < b"
  | a == b = "a == b"
