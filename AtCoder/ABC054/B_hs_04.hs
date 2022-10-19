-- https://atcoder.jp/contests/abc054/submissions/13420046
import Control.Monad ( replicateM )
import Data.List ( isPrefixOf )

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  a <- replicateM n getLine
  b <- replicateM m getLine
  putStrLn $ if null [()| i <- [0..n-m], j <- [0..n-m], check (map (drop j) (drop i a)) b] then "No" else "Yes"

check :: Eq a => [[a]] -> [[a]] -> Bool
check x y = and $ zipWith (flip isPrefixOf) x y
