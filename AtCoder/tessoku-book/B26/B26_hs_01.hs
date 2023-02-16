-- https://atcoder.jp/contests/tessoku-book/submissions/37897793
import Control.Monad ( forM_, when )
import Control.Monad.ST ( runST )
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = readLn >>= U.imapM_ (\i b -> when b $ print i) . sol

sol :: Int -> U.Vector Bool
sol n = runST $ do
  let m = n+1
  v <- UM.replicate m True
  UM.unsafeWrite v 0 False
  UM.unsafeWrite v 1 False
  forM_ (2:[3,5..m]) $ \p ->
    forM_ [p^2,p^2+p..m] $ \c ->
      UM.unsafeWrite v c False
  U.unsafeFreeze v
