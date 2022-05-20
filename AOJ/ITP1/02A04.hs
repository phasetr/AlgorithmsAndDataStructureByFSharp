main :: IO ()
main = getLine >>= putStrLn . solve . map read . words

solve :: [Int] -> String
solve [a, b] =
  case a `compare` b of
    LT -> "a < b"
    EQ -> "a == b"
    GT -> "a > b"
