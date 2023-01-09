-- https://atcoder.jp/contests/tessoku-book/submissions/35014871
main :: IO ()
main = do
  [_, c:_] <- words <$> getLine
  s <- getLine
  let score = sum $ map f s
      ans | score `mod` 3 == f c = "Yes"
          | otherwise = "No"
  putStrLn ans

f :: Num p => Char -> p
f 'W' = 0
f 'B' = 1
f _ = 2
