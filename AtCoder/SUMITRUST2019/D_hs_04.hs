-- https://atcoder.jp/contests/sumitrust2019/submissions/8745918
main :: IO ()
main = do
  _ <- getLine
  s <- getLine
  print $ solve s

solve :: String -> Int
solve s = length $ filter (isValid s) candidates

isValid :: String -> String -> Bool
isValid _ "" = True
isValid s (p:ps) =
  case dropWhile (/= p) s of
    [] -> False
    (_:s') -> isValid s' ps

candidates :: [String]
candidates = map (padding.show) [0..999] where
  padding s = replicate (3 - length s) '0' ++ s
