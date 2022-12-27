-- https://atcoder.jp/contests/tessoku-book/submissions/34968399
import Control.Monad ( replicateM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, q] <- getIntList
  as <- getIntList
  let vec = VU.fromList $ scanl (+) 0 as
  replicateM_ q $ do
    [l, r] <- getIntList
    print $ vec VU.! r - vec VU.! (l-1)
