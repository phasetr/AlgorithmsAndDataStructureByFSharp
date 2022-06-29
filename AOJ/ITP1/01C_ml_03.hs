main :: IO ()
main = getLine >>=
  print . unwords . map show . (\[a,b] -> [a*b, 2*(a+b)])
  . map read . words
