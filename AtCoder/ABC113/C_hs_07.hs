-- https://atcoder.jp/contests/abc113/submissions/5002201
{-# OPTIONS_GHC -O2 -funbox-strict-fields #-}
import Control.Monad.ST ( runST )
import Control.Monad.State.Strict ( StateT(StateT, runStateT) )
import qualified Data.ByteString.Char8      as B
import qualified Data.ByteString.Unsafe     as B
import           Data.Char                  (isSpace)
import qualified Data.Set                   as S
import qualified Data.Vector                as V
import qualified Data.Vector.Mutable        as VM
import qualified Data.Vector.Unboxed        as U

main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  pys <- U.unfoldrN m parseInt2 <$> B.getContents
  putStr $ solve n m pys

solve :: Int -> Int -> U.Vector (Int, Int) -> String
solve n m pys = unlines . map (tail . show) $ U.toList ids where
  ids = U.map (\(p, y) -> encodeId p (S.findIndex y (ss V.! (p - 1)) + 1)) pys
  ss = runST $ do
    v <- VM.replicate n S.empty
    U.forM_ pys $ \(p, y) ->
       VM.modify v (S.insert y) (p - 1)
    V.freeze v


encodeId :: Int -> Int -> Int
encodeId p r = 1000000000000 + p * 1000000 + r

type Parser a = B.ByteString -> Maybe (a, B.ByteString)

parseInt2 :: Parser (Int, Int)
parseInt2 = runStateT $
  (,) <$> StateT (B.readInt . B.dropWhile isSpace)
  <*> StateT (B.readInt . B.unsafeTail)
