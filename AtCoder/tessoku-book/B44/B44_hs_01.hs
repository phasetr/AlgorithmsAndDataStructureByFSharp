-- https://atcoder.jp/contests/tessoku-book/submissions/38764798
{-# LANGUAGE LambdaCase #-}
import Control.Monad ( replicateM, replicateM_ )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed.Mutable (unsafeWrite, unsafeRead)

main :: IO ()
main = do
  n <- readLn
  v <- U.unsafeThaw . U.fromListN (n^2) . concat =<< replicateM n get
  q <- readLn
  i <- U.unsafeThaw $ U.generate (n+1) id
  let
    swap x y = do
      x' <- unsafeRead i x
      y' <- unsafeRead i y
      unsafeWrite i x y'
      unsafeWrite i y x'
    idx x y = unsafeRead i x >>= unsafeRead v . (pred y +) . (n *) . pred
  replicateM_ q $ get >>= \case
    1:x:y:_ -> swap x y
    2:x:y:_ -> idx x y >>= print
get :: IO [Int]

get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine
