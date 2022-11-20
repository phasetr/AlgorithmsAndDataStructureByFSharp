-- https://atcoder.jp/contests/abc084/submissions/1926287
import Control.Monad ( when, forM_ )
import Data.Maybe ( fromJust )
import Control.Monad.ST ( ST, runST )
import Data.Array ( Array, listArray, (!) )
import Data.Array.ST ( freeze, readArray, writeArray, MArray(newArray), STUArray )
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  let a = buildSum (sieve 100000)
  q <- readLn
  forM_ [1..q] $ \_ -> do
    [l, r] <- map (fst . fromJust . B.readInt) . B.words <$> B.getLine
    print $ a!(r+1) - a!l

sieve :: Int -> Array Int Bool
sieve n = runST $ do
  a <- newArray (0, n) True :: ST s (STUArray s Int Bool)
  writeArray a 0 False
  writeArray a 1 False
  forM_ [2..n] $ \i -> do
    x <- readArray a i
    when x $ do
      forM_ [i*2, i*3 .. n] $ \j -> writeArray a j False
  freeze a

buildSum :: Array Int Bool -> Array Int Int
buildSum s =
  let n = length s - 1
  in listArray (0, n+1) . scanl (+) 0 . map (\i -> if s!i && s!((i+1)`div`2) then 1 else 0) $ [0..n]
