-- https://atcoder.jp/contests/tessoku-book/submissions/35595980
import Control.Monad
import qualified Data.ByteString.Char8 as BS
import Data.Char
import Data.List

import qualified Data.Heap as H

main = do
  [q] <- bsGetLnInts
  foldM_ (\h _ -> do
    qi <- bsGetLnInts
    case qi of
      1:x:_ -> return $ H.insert x h
      2:_   -> print (H.minimum h) >> return h
      3:_   -> return $ H.deleteMin h
    ) H.empty [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
