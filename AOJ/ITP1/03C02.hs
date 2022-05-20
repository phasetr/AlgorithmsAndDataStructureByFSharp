import Data.List
main :: IO ()
main = interact $ unlines
  . map (unwords . map show . sort . map read . words)
  . init . lines
