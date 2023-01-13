-- https://atcoder.jp/contests/tessoku-book/submissions/35575349
import qualified Data.ByteString.Char8 as BS
import qualified Data.Sequence as Q
import Control.Monad ( foldM_ )
import Data.List ( unfoldr )
import Data.Char ( isSpace )

main :: IO ()
main = do
  [q] <- bsGetLnInts
  foldM_ (\queue _ -> do
    li <- BS.getLine
    case (BS.index li 0, queue) of
      ('1', _) -> return (queue Q.:|> BS.tail (BS.tail li))
      ('2', n Q.:<| _) -> BS.putStrLn n >> return queue
      ('3', _ Q.:<| queue1) -> return queue1
      _error -> error "not come here"
    ) Q.empty [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
