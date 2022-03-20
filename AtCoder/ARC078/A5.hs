{-
https://atcoder.jp/contests/abc067/submissions/9267784
-}
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import Data.Char (isSpace)

main :: IO ()
main = do
  n <- readLn :: IO Int
  vec <- VU.unfoldrN n (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine :: IO (VU.Vector Int)
  let scan =  VU.init $ VU.tail $ VU.scanl (+) 0 vec
  print $ solve (VU.sum vec) scan

solve :: Int -> VU.Vector Int -> Int
solve s xs
  | VU.length xs == 1 = abs (s-2*VU.last xs)
  | otherwise = min (abs (s-2*VU.head xs)) (solve s $ VU.tail xs)
