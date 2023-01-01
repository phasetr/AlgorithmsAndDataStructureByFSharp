-- https://atcoder.jp/contests/tessoku-book/submissions/35262616
import Control.Monad ( when, forM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )

import Control.Monad.ST ( ST, runST )
import qualified Data.Vector.Unboxed.Mutable as MUV

tba22 :: Int -> [Int] -> [Int] -> Int
tba22 n as bs = runST action where
  action :: ST s Int
  action = do
    v <- MUV.replicate (succ n) (-1)
    MUV.write v 1 0
    forM_ (zip3 [1..] as bs) (\(i,a,b) -> do
      s <- MUV.read v i
      when (s >= 0) $ do -- 到達不能なマスからの移動を抑止
        MUV.modify v (max (s + 100)) a
        MUV.modify v (max (s + 150)) b
      )
    MUV.read v n

main :: IO ()
main = do
  [n] <- bsGetLnInts
  as <- bsGetLnInts
  bs <- bsGetLnInts
  let ans = tba22 n as bs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)
