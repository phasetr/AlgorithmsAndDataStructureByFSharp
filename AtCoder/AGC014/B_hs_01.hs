-- https://atcoder.jp/contests/agc014/submissions/11766336
import Control.Monad ( replicateM_ )
import qualified Data.ByteString.Char8       as BS
import Data.Maybe ( fromJust )
import qualified Data.Vector.Unboxed         as V
import qualified Data.Vector.Unboxed.Mutable as VM

main = do
  [n, m] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  d <- VM.new n
  VM.set d (0::Int)

  replicateM_ m $ do
    [a, b] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
    x <- VM.read d (a-1)
    VM.write d (a-1) (x+1)
    y <- VM.read d (b-1)
    VM.write d (b-1) (y+1)
  d' <- V.freeze d
  putStrLn $ if V.and $ V.map even d' then "YES" else "NO"
