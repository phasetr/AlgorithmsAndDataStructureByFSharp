-- https://atcoder.jp/contests/abc116/submissions/11378063
import Data.Functor ((<&>))

main :: IO ()
main = do
  n <- getLine <&> (read :: String -> Int)
  h <- getLine <&> map (read :: String -> Int) . words
  print $ solve h

solve :: (Foldable t, Ord b, Num b) => t b -> b
solve h = snd $ foldl f (0,0) h
  where f (a,b) c = (c, if a <= c then b + c - a else b)
