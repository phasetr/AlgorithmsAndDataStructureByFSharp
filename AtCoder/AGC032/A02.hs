{-
https://atcoder.jp/contests/agc032/submissions/10973527
-}
import Data.List (delete)

solve :: [Int] -> [Int] -> [Int]
solve xs acc
  | null xs = acc
  | null zs = []
  | otherwise = let (_,v) = maximum zs in solve (delete v xs) (v:acc)
  where
    l = length xs
    zs = filter (uncurry (==)) $ zip [1..l] xs

main :: IO ()
main = do
  n <- readLn :: IO Int
  bs <- map read . words <$> getLine
  case solve bs [] of
    [] -> print (-1)
    xs -> mapM_ print xs
