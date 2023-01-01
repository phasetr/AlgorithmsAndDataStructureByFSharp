-- https://atcoder.jp/contests/tessoku-book/submissions/37647461
import Control.Monad ( when, forM_ )
import Control.Monad.ST ( runST ) 
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = sol <$> readLn <*> get <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Int -> [Int] -> [Int] -> Int
sol n as bs = runST $ do
  v <- UM.replicate (n+1) (-1 :: Int)
  UM.unsafeWrite v 1 0
  forM_ (zip3 [1..] as bs) (\(i,a,b) -> do
    s <- UM.unsafeRead v i
    when (s>=0) $ do
      UM.modify v (max (s+100)) a
      UM.modify v (max (s+150)) b)
  UM.unsafeRead v n
