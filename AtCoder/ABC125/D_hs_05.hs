-- https://atcoder.jp/contests/abc125/submissions/5170997
{-# LANGUAGE ScopedTypeVariables #-}
import Data.Int ( Int64 )
import qualified Data.Vector.Unboxed as U
import qualified Data.ByteString.Char8 as BS

readInt :: BS.ByteString -> Int
readInt s = case BS.readInt s of
  Just (x, _) -> x
  _ -> error "not come here"

main :: IO ()
main = do
  n <- readInt <$> BS.getLine
  xs :: U.Vector Int64 <- U.fromListN n . map (fromIntegral . readInt) . BS.words <$> BS.getLine
  let negatives = U.filter (<= 0) xs
      abss = U.map abs xs
  if even (U.length negatives)
    then print $ U.sum $ U.map abs xs
    else print $ U.sum abss - 2 * U.minimum abss
