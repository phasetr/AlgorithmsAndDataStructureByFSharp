-- This is a pen.
-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_8_C
import Data.Char (toLower)
import Data.List (group,sort)
import Data.Map ((!?),fromList)
import Text.Printf (printf)

main :: IO ()
main = getLine >>= mapM_ putStrLn . solve

solve :: String -> [String]
solve s = map get ['a'..'z']
  where
    get c = case grouping !? c of
      Just n -> printf "%s : %d" [c] n
      Nothing -> printf "%s : 0" [c]
    grouping = fromList
      . map (\s -> (head s, length s)) . group
      . dropWhile (==' ') . sort
      $ map toLower s

test :: IO ()
test = print $ solve "This is a pen"
