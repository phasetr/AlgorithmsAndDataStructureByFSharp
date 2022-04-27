-- https://atcoder.jp/contests/dp/submissions/9952371
{-# LANGUAGE BangPatterns #-}
import qualified Data.ByteString.Char8 as B
import Data.Char ( isSpace )
import qualified Data.Vector.Unboxed as VU

solve :: Int -> VU.Vector Int -> VU.Vector Bool
solve !k !as =
  VU.constructN (k+1) $
  \ !vec ->
    let
      !i = VU.length vec
    in
      not $ VU.and $ VU.map (\a -> vec VU.! (i-a)) $ VU.takeWhile (<=i) as

main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine :: IO [Int]
  as <- VU.unfoldrN n (B.readInt . B.dropWhile isSpace) <$> B.getLine
  putStrLn $ if solve k as VU.! k then "First" else "Second"
