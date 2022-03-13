{-
https://atcoder.jp/contests/abc072/submissions/15716646
-}
import qualified Data.ByteString.Char8 as C
import Data.Vector.Unboxed as VU ((!),unfoldr,Vector)

main :: IO ()
main = C.interact $ put . solve . get where
  get = VU.unfoldr (C.readInt . C.dropWhile (<'0'))
  put = C.pack . show

solve :: VU.Vector Int -> Int
solve v = f 0 (v!0) where
  f c 0 = c
  f c 1 = c + if v VU.! 1==1 then 1 else 0
  f c i
    | v VU.! i==i && v VU.! (i-1)==i-1 = f (c+1) (i-2)
    | v VU.! i==i                      = f (c+1) (i-1)
    | otherwise                        = f c (i-1)
