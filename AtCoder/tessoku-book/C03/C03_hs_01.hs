-- https://atcoder.jp/contests/tessoku-book/submissions/35952501
import Control.Monad ( replicateM, replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

import Data.Array.Unboxed ( (!), listArray, UArray )

main :: IO ()
main = do
  [d] <- bsGetLnInts
  [x] <- bsGetLnInts
  as <- replicateM (pred d) (bsGetLnInts >>= return . head)
  let xA = listArray (1,d) $ scanl (+) x as :: UArray Int Int
  [q] <- bsGetLnInts
  replicateM_ q $ do
    [s,t] <- bsGetLnInts
    let ans = case compare (xA ! s) (xA ! t) of {
      LT -> show t;
      EQ -> "Same";
      GT -> show s}
    putStrLn ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine >>= return . unfoldr (BS.readInt . BS.dropWhile isSpace)
