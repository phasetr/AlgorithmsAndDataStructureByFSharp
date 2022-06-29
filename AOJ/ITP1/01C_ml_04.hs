import Control.Applicative
main :: IO ()
main = do
  [a, b] <- map read . words <$> getLine
  putStrLn . unwords . map show $ [a*b, 2*(a+b)]
