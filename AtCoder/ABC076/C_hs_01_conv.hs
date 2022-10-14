-- https://atcoder.jp/contests/abc076/submissions/9944686
main :: IO ()
main = do
  s <- getLine
  t <- getLine
  putStrLn $ solve s t

f :: [(Char, Char)] -> Bool
f [] = True
f ((a,b):s) = not (a /= '?' && a /= b) && f s

solve :: String -> String -> String
solve s t = if null ss then "UNRESTORABLE" else minimum ss where
  sl = length s
  tl = length t
  ss = [map (\c -> if c=='?' then 'a' else c) $ take i s ++ t ++ drop (i+tl) s
       | i <- [0..sl-tl], f $ zip (take tl $ drop i s) t]

test = do
  print $ solve "?tc????" "coder"
  print $ solve "??p??d??" "abc"
  print $ solve "?????" "z"
  print $ solve "???z?" "z"
