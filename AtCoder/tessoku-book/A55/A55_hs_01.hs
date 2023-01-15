-- https://atcoder.jp/contests/tessoku-book/submissions/35596452
import Control.Monad ( foldM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.IntSet as IS
import Data.Maybe ( fromMaybe )

main :: IO ()
main = do
  [q] <- bsGetLnInts
  foldM_ (\s _ -> do
    qi <- bsGetLnInts
    case qi of
      1:x:_ -> return $ IS.insert x s
      2:x:_ -> return $ IS.delete x s
      3:x:_ -> print (fromMaybe (-1) $ IS.lookupGE x s) >> return s
      _err  -> error "not come here"
    ) IS.empty [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
