-- https://atcoder.jp/contests/tessoku-book/submissions/35575684
import Control.Monad ( forM_, forM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  as <- zip [2..] <$> getIntList
  let edge = V.create $ do
        vec <- VM.replicate n ([] :: [Int])
        forM_ as $ \(x, y) -> do VM.modify vec ((x-1) :) (y-1)
        return vec

  let buka = VU.create $ do
        vec <- VUM.replicate n (0 :: Int)
        forM_ [n-1,n-2..0] $ \i -> do
          let bukaList = edge V.! i
          bukas <- forM bukaList $ \j -> do
            x <- VUM.read vec j
            return $ x + 1
          VUM.write vec i $ sum bukas
        return vec
  putStrLn . unwords . map show $ VU.toList buka
