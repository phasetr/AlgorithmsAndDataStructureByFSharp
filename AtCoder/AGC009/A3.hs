{-
https://atcoder.jp/contests/agc009/submissions/13265167
-}
import Control.Monad
import Data.Maybe
import qualified Data.ByteString.Char8 as BS
import Data.List

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  ab <- replicateM n $ do
      [a,b] <- getIntList
      return (a,b)
  print $ solve ab
  where
    readInt = fst . fromJust . BS.readInt
    readIntList = map readInt . BS.words
    getInt = readInt <$> BS.getLine
    getIntList = readIntList <$> BS.getLine

solve :: [(Int, Int)] -> Int
solve = foldr (\(a,b) k -> k + ((-a-k) `mod` b)) 0
