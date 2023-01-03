-- https://atcoder.jp/contests/tessoku-book/submissions/35005860
import Control.Monad ( forM_, forM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector.Mutable as VM
import qualified Data.Array.Unboxed as AU
import qualified Data.Bits as B
import qualified Data.Set as S

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, x, y] <- getIntList
  as <- getIntList
  let gs = grundy [x, y] (maximum as)
  let p = foldl1 B.xor $ map (gs VU.!) as
      ans | p == 0 = "Second"
          | otherwise = "First"
  putStrLn ans

grundy :: [Int] -> Int -> VU.Vector Int
grundy xs n = vec where
  vec = VU.create $ do
    v <- VUM.replicate (n+1) 0
    forM_ [0..n] $ \i -> do
      ps <- forM xs $ \j -> if 0 <= i - j then do VUM.read v (i - j) else do return (-1)
      VUM.write v i $ mex ps
    return v

mex :: [Int] -> Int
mex xs = mex' 0 where
  s = S.fromList xs
  mex' k | S.member k s = mex' (k+1)
         | otherwise = k
