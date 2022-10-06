-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/3600263/rabbisland/Haskell
import Control.Monad ( foldM_, replicateM )
import Data.ByteString.Char8 (ByteString)
import qualified Data.ByteString.Char8 as B
import Data.List ( unfoldr )
import Data.Char (isSpace)
import Data.Sequence ((<|), (|>), ViewL(..), ViewR(..), Seq)
import qualified Data.Sequence as Sq

main :: IO ()
main = do
  q <- readLn
  replicateM q f >>= solve
  where f = fmap (readil B.readInt) B.getLine

solve :: [[Int]] -> IO ()
solve = foldM_ f Sq.empty where
  f sq [0, d, x] = push sq d x
  f sq [1, p] = do
    randomAccess sq p >>= print
    return sq
  f sq [2, d] = pop sq d
  f _ _ = error "not come here"

push :: Seq Int -> Int -> Int -> IO (Seq Int)
push sq d x
  | d == 0 = return $ x <| sq
  | otherwise = return $ sq |> x

randomAccess :: Seq Int -> Int -> IO Int
randomAccess sq p = return $ Sq.index sq p

pop :: Seq Int -> Int -> IO (Seq Int)
pop sq d
  | d == 0 = let (_ :< sq') = Sq.viewl sq in return sq'
  | otherwise = let (sq' :> _) = Sq.viewr sq in return sq'

readil :: Integral a =>  (ByteString -> Maybe (a, ByteString)) -> ByteString -> [a]
readil f = unfoldr $ \s -> do
  (n, s') <- f s
  return (n, B.dropWhile isSpace s')

