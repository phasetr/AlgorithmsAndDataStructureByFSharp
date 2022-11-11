-- https://atcoder.jp/contests/abc134/submissions/13959277
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM

main :: IO ()
main = do
  n <- fst . fromJust . BS.readInt <$> BS.getLine
  as <- VU.fromList . (map (fst . fromJust . BS.readInt) . BS.words) <$> BS.getLine
  let ans = VU.toList $ solve n as
  print $ sum ans
  putStrLn . unwords . filter (/= "") $ zipWith (\i a -> if a==1 then show i else "") [1..] ans

solve :: Int -> VU.Vector Int -> VU.Vector Int
solve n as = VU.create $ do
  vec <- VUM.replicate n 0
  forM_ [n,n-1..1] $ \i -> do
    ai' <- (`mod` 2) . sum <$> mapM (VUM.read vec) [i-1,2*i-1..n-1]
    VUM.write vec (i-1) (abs ((as VU.! (i-1)) - ai'))
  return vec

test = do
  let (n,as) = (3, VU.fromList [1,0,0])
  let ans = VU.toList $ solve n as
  print ans
  putStrLn . unwords . filter (/= "") $ zipWith (\i a -> if a==1 then show i else "") [1..] ans
  let (n,as) = (5, VU.fromList [0,0,0,0,0])
  let ans = VU.toList $ solve n as
  print ans
  putStrLn . unwords . filter (/= "") $ zipWith (\i a -> if a==1 then show i else "") [1..] ans
