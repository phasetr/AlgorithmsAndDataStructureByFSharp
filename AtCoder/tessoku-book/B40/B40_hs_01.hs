-- https://atcoder.jp/contests/tessoku-book/submissions/38559165
import Control.Monad ( foldM )
import Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = (C.getLine *> get) >>= print . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> Int
sol as = runST $ do
  v <- UM.replicate 100 (0::Int)
  foldM (\s a -> do
    a' <- UM.unsafeRead v ((-a) `mod` 100)
    UM.unsafeRead v a >>= UM.unsafeWrite v a . succ
    return $ s+a') 0 $ map (`mod` 100) as
