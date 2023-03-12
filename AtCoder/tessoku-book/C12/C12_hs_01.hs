-- https://atcoder.jp/contests/tessoku-book/submissions/36176712
import Control.Monad ( forM_, forM, replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Array.Unboxed as A
import qualified Data.Array.ST as AM

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, m, k] <- getIntList
  ab <- replicateM m $ do
    [a, b] <- getIntList
    return (a, b)
  let score l r = length [() | (a, b) <- ab, l <= a && b <= r]
  let result = AM.runSTArray $ do
        arr <- AM.newArray ((0, 0), (k, n)) (0 :: Int)
        forM_ [1..k] $ \i -> do
          forM_ [1..n] $ \j -> do
            totalScore <- forM [i-1..j-1] $ \s -> do
                p <- AM.readArray arr (i-1, s)
                return $ p + (score (s+1) j)
            AM.writeArray arr (i, j) $ maximum (0 : totalScore)
        return arr
  print $ result A.! (k, n)
