-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_9_A
import Control.Applicative ((<$>))
import Data.Char (toLower)
main :: IO ()
main = do
  w <- getLine
  t <- concatMap words . init . lines . map toLower <$> getContents
  print $ solve w t

solve :: String -> [String] -> Int
solve w t = length $ filter (==w) t

test = print $ solve "computer" (words $ map toLower "Nurtures computer scientists and highly skilled computer engineers who will create and exploit knowledge for the new era Provides an outstanding computer environment") == 3
