{-
https://atcoder.jp/contests/abc068/submissions/8342545
-}
import qualified Data.ByteString.Char8 as BS
import Data.Maybe (fromJust)
import Data.Array.IArray

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine :: IO [Int]
  ab <- map ((\[a,b] -> (a,b)) . map (fst . fromJust . BS.readInt) . BS.words)
        . BS.lines <$> BS.getContents :: IO [(Int,Int)]
  putStrLn $ if solve n m ab then "POSSIBLE" else "IMPOSSIBLE"

solve :: (Num a, Ix a) => a -> a -> [(a, a)] -> Bool
solve n m ab = n `elem` ps where
  adjacencyList :: (Ix a) => a -> a -> [(a,a)] -> Array a [a]
  adjacencyList bgn end = accumArray (flip (:)) [] (bgn,end)

  g = adjacencyList 1 (max n m) ab
  ps = concat [g!p | p <- g!1]
