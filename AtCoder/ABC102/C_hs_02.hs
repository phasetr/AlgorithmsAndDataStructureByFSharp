-- https://atcoder.jp/contests/abc102/submissions/24025558
import qualified Data.ByteString.Char8 as C
import Data.Char

import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Algorithms.Intro as VAI

main :: IO ()
main = do
  n <- readLn :: IO Int
  as <- VU.unfoldrN n (C.readInt . C.dropWhile isSpace) <$> C.getLine
  bs <- VU.thaw $ VU.imap (\i a -> a - (i + 1)) as
  VAI.sort bs
  bs' <- VU.freeze bs
  let b = bs' VU.! (n `div` 2)
  print $ VU.sum $ VU.imap (\i a -> abs $ a - (b + i + 1)) as
