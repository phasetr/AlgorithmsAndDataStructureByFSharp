-- https://atcoder.jp/contests/tessoku-book/submissions/36372187
import Control.Monad (forM_, replicateM)
import Data.Array (Array, accumArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (intercalate, unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

graph :: (Int, Int) -> [[Int]] -> Array Int [Int]
graph (i, n) uvs = accumArray (flip (:)) [] (i, n) xs
  where xs = concatMap (\[u, v] -> [(u, v), (v, u)]) uvs

main :: IO ()
main = do
  [n, m] <- getInts
  uvs <- replicateM m getInts

  let g = graph (1, n) uvs

  forM_ [1 .. n] $ \i -> do
    let s = intercalate ", " $ map show (g ! i)
    putStrLn $ concat [show i, ": ", "{", s, "}"]
