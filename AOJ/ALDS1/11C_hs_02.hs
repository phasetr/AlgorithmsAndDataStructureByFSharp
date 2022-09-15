-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/2916468/lvs7k/Haskell
import Control.Monad ( forM_, filterM )
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust )
import Control.Monad.ST ( ST )
import Data.Array.IArray ( Array, (!), array )
import Data.Array.MArray
    ( readArray, writeArray, MArray(newArray) )
import Data.Array.ST
    ( readArray, writeArray, MArray(newArray), STUArray, runSTUArray )
import Data.Array.Unboxed ( Array, (!), array, UArray )
import qualified Data.Sequence as S

readi :: B.ByteString -> Int
readi = fst . fromJust . B.readInt

bfs :: Int -> Array Int [Int] -> UArray Int Int
bfs n grp = runSTUArray $ do
  d <- newArray (1, n) (-1) :: ST s (STUArray s Int Int)
  writeArray d 1 0
  go (S.singleton 1) d
  return d
  where
    go q d
      | S.EmptyL  <- S.viewl q = return ()
      | x S.:< xs <- S.viewl q = do
          xd <- readArray d x
          vs <- filterM (fmap (== -1) . readArray d) (grp ! x)
          forM_ vs $ \v -> writeArray d v (xd + 1)
          go (xs S.>< S.fromList vs) d

main :: IO ()
main = do
  n <- readLn
  xss <- fmap (fmap (fmap readi . B.words) . B.lines) B.getContents
  let f [i, 0]   = (i, [])
      f (i:_:is) = (i, is)
      f _ = error "not come here"
  let grp = array (1, n) (fmap f xss)
  let dst = bfs n grp
  forM_ [1 .. n] $ \i -> do
    putStrLn . unwords $ fmap show [i, dst ! i]
