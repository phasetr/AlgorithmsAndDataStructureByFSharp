-- https://atcoder.jp/contests/tessoku-book/submissions/35006088
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Array.Unboxed as AU
import qualified Data.Array.ST as AM

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  as <- getIntList
  let pyramid = AM.runSTUArray $ do
        arr <- AM.newArray ((1,1), (n,n)) (0 :: Int)
        forM_ (zip [1..n] as) $ \(i, a) -> do
          AM.writeArray arr (n, i) a
        forM_ [n-1,n-2..1] $ \i -> do
          forM_ [1..i] $ \j -> do
            x <- AM.readArray arr (i+1, j)
            y <- AM.readArray arr (i+1, j+1)
            if odd i
            then AM.writeArray arr (i, j) $ max x y
            else AM.writeArray arr (i, j) $ min x y
        return arr
  print $ pyramid AU.! (1,1)
