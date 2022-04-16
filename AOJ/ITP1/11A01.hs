-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_11_A
main :: IO ()
main = do
  dice <- fmap words getLine
  s <- getLine
  putStrLn $ solve s $ (\[a,b,c,d,e,f] -> (a,b,c,d,e,f)) dice
solve :: String -> (f, f, f, f, f, f) ->  f
solve s dice = (\(d,_,_,_,_,_) -> d) $ help dice s where
  help d [] = d
  help (a,b,c,d,e,f) xs = case head xs of
    'E' -> help (d,b,a,f,e,c) (tail xs)
    'N' -> help (b,f,c,d,a,e) (tail xs)
    'S' -> help (e,a,c,d,f,b) (tail xs)
    _   -> help (c,b,f,a,e,d) (tail xs)

test :: IO ()
test = do
  print $ solve "SE" (1,2,4,8,16,32) == 8
  print $ solve "EESWN" (1,2,4,8,16,32) == 32
