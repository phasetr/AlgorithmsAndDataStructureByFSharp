-- https://atcoder.jp/contests/tessoku-book/submissions/35458720
import Control.Monad ( foldM )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import Data.Array.IO
    ( newListArray, readArray, writeArray, IOUArray )

main :: IO Bool
main = do
  [n,q] <- bsGetLnInts
  arr <- newListArray (1,n) [1..n] :: IO (IOUArray Int Int)
  foldM (\dir _ -> do
    qu <- bsGetLnInts
    case qu of
      1:x:y:_ -> writeArray arr (if dir then x else n-x+1) y >> return dir
      2:_ -> return $ not dir
      3:x:_ -> readArray arr (if dir then x else n-x+1) >>= print >> return dir
      _err -> error "not come here"
    ) True [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
