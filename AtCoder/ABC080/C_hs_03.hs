-- https://atcoder.jp/contests/abc080/submissions/17898308
import Data.Bits ( Bits((.&.), popCount) )
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector as V

main :: IO ()
main = sub =<< readLn

sub :: Int -> IO ()
sub n = sol <$> get n 10 <*> get n 11 >>= print

get :: Int -> Int -> IO (V.Vector (U.Vector Int))
get n m = V.replicateM n $ U.unfoldrN m (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: V.Vector (U.Vector Int) -> V.Vector (U.Vector Int) -> Int
sol fs ps = maximum [V.sum $ V.zipWith (ev b) fs ps | b <- [1..1023]]

ev :: (Bits a, U.Unbox c, U.Unbox a, Num a) => a -> U.Vector a -> U.Vector c -> c
ev b f p = (p U.!) . popCount $ b .&. U.foldl1' ((+) . (2*)) f
