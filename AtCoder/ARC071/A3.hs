{-
https://atcoder.jp/contests/abc058/submissions/21852488
-}
import Control.Monad (replicateM)
import qualified Data.Map.Strict as M

main :: IO ()
main = do
  n <- readLn
  ss <- replicateM n getLine
  putStrLn $ solve n ss

solve :: Int -> [String] -> String
solve n ss = concatMap (\c -> replicate (f c) c) ['a'..'z']
  where f c = minimum $ map (length . filter (==c)) ss
