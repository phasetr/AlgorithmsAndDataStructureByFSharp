-- https://atcoder.jp/contests/abc153/submissions/18501601
import Control.Monad ( forM_ )
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as VM
main :: IO ()
main = print . solve . unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents

solve :: [Int] -> Int
solve (h:n:ab) = (V.! h) . f h $ V.unfoldrN n (\(a:b:ab) -> Just ((a,b),ab)) ab where
  f h ab = V.create $ do
    dp <- VM.replicate (h+1) (maxBound `div` 2)
    VM.write dp 0 0
    V.forM_ ab $ \(a,b) ->
      forM_ [1..h] $ \i -> do
        v1 <- VM.read dp i
        v2 <- VM.read dp $ max(i-a)0
        VM.write dp i $ min v1 $ v2+b
    return dp
solve _ = error "not come here"
