-- https://atcoder.jp/contests/code-festival-2016-qualb/submissions/11950449
import Data.Bool
import Data.List

readLineInputs :: Read a => IO [a]
readLineInputs = map read . words <$> getLine

main :: IO ()
main = do
  [n,a,b] <- readLineInputs
  s <- getLine
  mapM_ putStrLn $ solve a b s

{- |
>>> solve 2 3 "abccabaabb"
["Yes","Yes","No","No","Yes","Yes","Yes","No","No","No"]
>>> solve 5 2 "cabbabaacaba"
["No","Yes","Yes","Yes","Yes","No","Yes","Yes","No","Yes","No","No"]
>>> solve 2 2 "ccccc"
["No","No","No","No","No"]
-}
solve :: Int -> Int -> String -> [String]
solve a b s = unfoldr psi (0, 0, s)
  where
    psi (x,y,"") = Nothing
    psi (x,y,z:zs) = case z of
      'a' -> Just $ bool ("Yes", (succ x, y, zs)) ("No", (x, y, zs)) (a+b <= x+y)
      'b' -> Just $ bool ("Yes", (x, succ y, zs)) ("No", (x, y, zs)) (a+b <= x+y || b <= y)
      'c' -> Just ("No", (x, y, zs))
