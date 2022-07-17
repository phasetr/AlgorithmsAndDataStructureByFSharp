-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_C/review/4595067/mitsuki114/Haskell
import Data.List (intercalate,intersperse)
solve :: (Num a, Eq a) => a -> a -> a -> [[a]] -> a
solve b f r ss = sum $ [last s | s <- ss, init s == [b, f, r]]

main :: IO ()
main = do
  _ <- getLine
  ss <- fmap (map (map read . words) . lines) getContents
  putStrLn
    $ intercalate "\n"
    $ intersperse (replicate 20 '#')
    [intercalate "\n"
     [' ' : unwords [show $ solve b f r ss | r <-[1..10]]
     | f <- [1..3]] | b <- [1..4]]
