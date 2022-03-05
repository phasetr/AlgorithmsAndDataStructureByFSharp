{-
https://atcoder.jp/contests/abc066/submissions/28096651
-}
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = do
   n <- readLn
   as <- map (read::String->Int). words <$> getLine
   putStrLn $ unwords $ map show $ solve n as

solve :: Int -> [Int] -> [Int]
solve n as = map (\i -> v VU.! (i-1)) $ indices n
  where
    v = VU.fromList as

indices :: Int -> [Int]
indices n
   | odd n   = [n,n-2..1] ++ [2,4..n-1]
   | otherwise = [n,n-2..2] ++ [1,3..n-1]

test :: IO ()
test = do
  print $ solve 4 [1,2,3,4] == [4,2,1,3]
  print $ solve 3 [1,2,3] == [3,1,2]
  print $ solve 1 [1000000000] == [1000000000]
  print $ solve 6 [0,6,7,6,7,0] == [0,6,6,0,7,7]
