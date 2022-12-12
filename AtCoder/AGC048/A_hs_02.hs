-- https://atcoder.jp/contests/agc038/submissions/7648876
{-# LANGUAGE OverloadedStrings #-}
import Control.Monad ( replicateM_ )
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  [h, w, a, b] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  let s = BS.replicate a '0' `BS.append` BS.replicate (w-a) '1'
  let s' = BS.replicate a '1' `BS.append` BS.replicate (w-a) '0'
  replicateM_ b $ BS.putStrLn s
  replicateM_ (h-b) $ BS.putStrLn s'
