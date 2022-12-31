-- https://atcoder.jp/contests/dp/submissions/31091752
import Data.List ( scanl' )
main :: IO ()
main = do
  s <- getLine
  t <- getLine
  putStrLn $ solve s t

solve :: String -> String -> String
solve s t = reverse . snd . last $ foldl f (repeat (0,[])) s where
  f :: [(Int, String)] -> Char -> [(Int, String)]
  f xs si = tail $ scanl' g (0,[]) $ zip3 ((0,[]):xs) xs t where
    g (n,l) ((x0,l0),(x1,l1),tj)
      | si==tj = (x0+1,si:l0)
      | n>x1 = (n,l)
      | otherwise = (x1,l1)

test :: IO ()
test = do
  print $ t
  print $ xs
  print $ foldl f (repeat (0,[])) s
  print 1
  where
    s = "mynavi"
    t = "monday"
    xs = [(0,[])] :: [(Int, String)]
    f xs si = tail $ scanl' g (0,[]) $ zip3 ((0,[]):xs) xs t where
      g (n,l) ((x0,l0),(x1,l1),tj)
        | si==tj = (x0+1,si:l0)
        | n>x1 = (n,l)
        | otherwise = (x1,l1)
