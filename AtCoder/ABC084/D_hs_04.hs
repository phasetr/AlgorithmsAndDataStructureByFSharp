-- https://atcoder.jp/contests/abc084/submissions/29808715
import Control.Monad ( when, forM_, foldM_, replicateM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )

import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as MV

main :: IO ()
main = do
  [q] <- bsGetLnInts
  replicateM_ q $ do
    [l,r] <- bsGetLnInts
    print $ (cuarr V.! r) - (cuarr V.! pred l)

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

cuarr :: V.Vector Int
cuarr = V.create (do
  v <- MV.replicate (ub+1) 0
  foldM_ (cuarrstep v) 0 [1..ub]
  return v
  )

cuarrstep v cnt k = do
  let x = primev V.! k
  let y = primev V.! (succ k `div` 2)
  let cnt1 = if x && y then succ cnt else cnt
  MV.write v k cnt1
  return cnt1

{-
上限10^5までのエラトステネスの篩を作っておく。
上限までの、2017に似た数の個数の累積和を作っておく。
そこから区間の個数を求める。
奇数だけ処理すると半分の時間で済むが、1の手前が-1になってしまうので妥協。
-}

-- @gotoki_no_joe
ub = 10^5 :: Int -- 上限
primev = V.create (do
  v <- MV.replicate (ub+1) True
  MV.write v 0 False
  MV.write v 1 False
  forM_ [2..316] (\i -> do
    f <- MV.read v i
    when f (forM_ [i*i,i*succ i..ub] (\j -> MV.write v j False)))
  return v
  )
