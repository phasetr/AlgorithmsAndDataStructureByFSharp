{-
https://atcoder.jp/contests/abc067/submissions/22255877
-}
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as VU
import Data.Char (isSpace)

main :: IO ()
main = do
  n <- readLn :: IO Int
  as <- VU.unfoldr (C.readInt . C.dropWhile isSpace) <$> C.getLine
  print $ solve n as

solve :: Int -> VU.Vector Int -> Int
solve n as = VU.minimum
  $ VU.map (\(a,b) -> abs (a-b))
  $ VU.slice 1 (n-1)
  $ VU.scanl' (\(as, bs) a -> (as+a, bs-a)) (0, VU.sum as) as

--orig :: VU.Vector Int -> Int
--orig as = VU.minimum
--  $ VU.map (\(a,b) -> abs (a-b))
--  $ VU.init
--  $ VU.tail
--  $ VU.scanl' (\(as, bs) a -> (as+a, bs-a)) (0, VU.sum as) as
