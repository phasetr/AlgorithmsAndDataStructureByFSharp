-- https://atcoder.jp/contests/tessoku-book/submissions/35008533
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sort )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  lr <- fmap sort . replicateM n $ do
    [l, r] <- getIntList
    return (r, l)
  let (m, _) = foldl f (0, 0) lr where
        f (k, pre) (r, l) | pre <= l = (k+1, r)
                          | otherwise = (k, pre)
  print m
