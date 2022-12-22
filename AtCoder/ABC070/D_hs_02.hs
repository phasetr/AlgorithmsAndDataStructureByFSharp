-- https://atcoder.jp/contests/abc070/submissions/15493865
import Control.Monad ( Monad(return, (>>=)), Functor(fmap), when )
import qualified Data.ByteString.Char8 as C
import Data.Foldable ( forM_ )
import Data.Maybe ( Maybe(Just) )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Data.Vector.Unboxed
    ( (!), create, drop, splitAt, tail, unfoldr )
import qualified Data.Vector.Unboxed.Mutable as UM
import Prelude hiding (drop, splitAt, tail, unfoldr)

main :: IO ()
main = C.interact $ put . sol . get

get = unfoldr (C.readInt . C.dropWhile (<'0'))

put :: V.Vector Int -> C.ByteString
put = C.unlines . fmap (C.pack . show) . V.toList

sol v = fmap (\q -> ds!(q!0) + ds!(q!1)) qs where
  n = v!0
  (v0,v1) = splitAt (3*(n-1)) $! tail v
  es = V.unfoldrN (n-1) (Just . splitAt 3) v0
  q = v1!0
  k = v1!1
  qs = V.unfoldrN q (Just . splitAt 2) $! drop 2 v1
  tr = V.create $ do
    v <- VM.replicate (n+1) []
    let add x (y,z) = VM.unsafeRead v x >>= VM.unsafeWrite v x . ((y,z):)
    V.forM_ es $ \e -> do
      add (e!0) (e!1,e!2)
      add (e!1) (e!0,e!2)
    return v
  ds = create $ do
    v <- UM.replicate (n+1) (-1)
    loop v (k,0)
    return v
  loop v (nd,d) = do
    UM.unsafeWrite v nd d
    Data.Foldable.forM_ (tr V.! nd) $ \(nd',d') -> do
      x <- UM.unsafeRead v nd'
      when (x<0) $ loop v (nd',d+d')
