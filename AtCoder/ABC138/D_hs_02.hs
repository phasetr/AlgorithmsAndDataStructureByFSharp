-- https://atcoder.jp/contests/abc138/submissions/14926247
{-# LANGUAGE Strict #-}
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( delete, unfoldr )
import Data.Array ( elems, array, (!), accumArray )
import Control.Monad ( forM )

main :: IO ()
main = do
  li <- BS.getLine
  let [n,q] = unfoldr (BS.readInt . BS.dropWhile isSpace) li
  abs <- forM [2..n] get2
  pxs <- forM [1..q] get2
  let ans = compute n q abs pxs
  putStrLn $ unwords $ map show ans

get2 :: p -> IO (Int, Int)
get2 _ = do
  li <- BS.getLine
  let [a,b] = unfoldr (BS.readInt . BS.dropWhile isSpace) li
  return (a,b)

compute :: Int -> Int -> [(Int,Int)] -> [(Int,Int)] -> [Int]
compute n _ abs pxs = ans where
  xa = accumArray (+) 0 (1,n) pxs
  ta = accumArray (flip (:)) [] (1,n) [ p | (a,b) <- abs, p <- [(a,b),(b,a)] ]
  ans = elems $ array (1,n) $ dft 0 0 1 []
  dft p v cur rest = (cur, v1) : foldr (dft cur v1) rest (delete p $ ta ! cur)
    where v1 = v + xa ! cur
