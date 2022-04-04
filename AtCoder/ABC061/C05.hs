-- https://atcoder.jp/contests/abc061/submissions/12961752
import Control.Monad (replicateM)
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as BS
import Data.List (scanl',sort)

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n,k] <- getIntList
  abs <- replicateM n $ do
    [a,b] <- getIntList
    return (a,b)
  let (as,bs) = unzip $ sort abs
  print . (as !!) . pred . length . takeWhile (<k)
    $ scanl' (+) 0 bs
