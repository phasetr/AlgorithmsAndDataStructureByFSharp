-- https://atcoder.jp/contests/tessoku-book/submissions/35596826
import Control.Monad ( replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import qualified Data.IntSet as IS
import Data.Maybe ()

main :: IO ()
main = do
  [n,q] <- bsGetLnInts
  s <- BS.getLine
  replicateM_ q $ do
    [a,b,c,d] <- bsGetLnInts
    let ans = ft s a b == ft s c d
    putStrLn $ if ans then "Yes" else "No"

ft :: BS.ByteString -> Int -> Int -> BS.ByteString
ft s a b = BS.drop (pred a) $ BS.take b s

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
