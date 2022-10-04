-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/3599427/rabbisland/Haskell
import Control.Monad ( foldM_, replicateM )
import Data.ByteString.Char8 (ByteString)
import qualified Data.ByteString.Char8 as B
import Data.List ( unfoldr )
import Data.Char (isSpace)
import Data.Sequence ((|>), ViewR(..), Seq)
import qualified Data.Sequence as Sq

main :: IO ()
main = do
  q <- readLn
  replicateM q f >>= solve
  where f = fmap (readil B.readInt) B.getLine

solve :: [[Int]] -> IO ()
solve = foldM_ f Sq.empty where
  f sq [0, x] = pushBack sq x
  f sq [1, p] = do
    randomAccess sq p >>= print
    return sq
  f sq _ = popBack sq

pushBack :: Seq Int -> Int -> IO (Seq Int)
pushBack sq x = return $ sq |> x

randomAccess :: Seq Int -> Int -> IO Int
randomAccess sq p = return $ Sq.index sq p

popBack :: Seq Int -> IO (Seq Int)
popBack sq = let (sq' :> _) = Sq.viewr sq in return sq'

readil :: Integral a =>  (ByteString -> Maybe (a, ByteString)) -> ByteString -> [a]
readil f = unfoldr $ \s -> do
  (n, s') <- f s
  return (n, B.dropWhile isSpace s')
