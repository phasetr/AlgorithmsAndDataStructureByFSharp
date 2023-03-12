-- https://atcoder.jp/contests/tessoku-book/submissions/36140821
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  as <- VU.fromList <$> getIntList
  let result = VU.create $ do
        vec <- VUM.replicate (n+1) (0 :: Int)
        VUM.write vec 1 (as VU.! 0)
        forM_ [2..n] $ \i -> do
          m1 <- VUM.read vec (i-1)
          m2 <- VUM.read vec (i-2)
          let m = max m1 (m2 + as VU.! (i-1))
          VUM.write vec i m
        return vec
  print $ result VU.! n
