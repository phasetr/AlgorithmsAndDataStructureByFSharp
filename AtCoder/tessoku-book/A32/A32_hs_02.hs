-- https://atcoder.jp/contests/tessoku-book/submissions/35004878
import Control.Monad ( forM_, when )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Array.Unboxed as AU
import qualified Data.Array.ST as AM

main :: IO ()
main = do
  [n, a, b] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  let vec = VU.create $ do
        v <- VUM.replicate (n+1) False
        let x = min a b
            y = max a b
        forM_ [0..n] $ \i -> do
            when (x <= i && i < y) $ do
                p <- VUM.read v (i - x)
                VUM.write v i $ not p
            when (y <= i) $ do
                p <- VUM.read v (i - x)
                q <- VUM.read v (i - y)
                VUM.write v i $ not (p && q)
        return v
      winner | vec VU.! n = "First"
             | otherwise = "Second"
  putStrLn winner
