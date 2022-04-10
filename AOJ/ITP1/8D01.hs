-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_8_D
import Data.List (isInfixOf)
main :: IO ()
main = do
  s <- getLine
  p <- getLine
  putStrLn $ solve s p
solve :: Eq a => [a] -> [a] -> String
solve s p = if p `isInfixOf` (s++s) then "Yes" else "No"

test :: IO ()
test = print $ solve "vanceknowledgetoad" "advance" == "Yes"
  && solve "vanceknowledgetoad" "advanced" == "No"
