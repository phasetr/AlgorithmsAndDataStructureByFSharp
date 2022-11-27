-- https://atcoder.jp/contests/arc058/submissions/1550578
main :: IO ()
main = do
  f <- getLine
  s <- getLine
  let (n,k) = parse1 f
  let d = parse2 s
  print $ solve n k d

parse1 :: String -> (Int, Int)
parse1 str = (head w, w !! 1) where w = map read $ words str

parse2 :: String -> String
parse2 = concat . words

solve :: Int -> Int -> String -> Int
solve n k d = head $ filter out [n..9999999]
  where out k = let s = show k in all (`notElem` s)  d
