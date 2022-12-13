-- https://atcoder.jp/contests/abc124/submissions/4950714
{-# LANGUAGE ScopedTypeVariables #-}
import Data.List (foldl')
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  [n,k] :: [Int] <- map (read . BS.unpack) . BS.words <$> BS.getLine
  s <- BS.getLine
  let countStanding s | BS.null s = []
                      | (a,b) <- BS.span (== '0') s = BS.length a : countHandstanding b
      countHandstanding s | BS.null s = [0]
                          | (a,b) <- BS.span (== '1') s = BS.length a : countStanding b
      standing = U.fromListN n $ countHandstanding s
      ss = U.scanl' (+) 0 standing
  if U.length ss > 2 * k + 1
    then print $ maximum [ss U.! (2*(i+k)+1) - ss U.! (2 * i) | i <- [0..(U.length ss `quot` 2) - k - 1]]
    else print n
