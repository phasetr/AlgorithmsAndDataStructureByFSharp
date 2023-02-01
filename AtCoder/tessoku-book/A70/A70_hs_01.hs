-- https://atcoder.jp/contests/tessoku-book/submissions/35840406
import Control.Monad ( replicateM, forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( foldl' )
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.IntSet as IS
import qualified Data.Bits as B

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  [n, m] <- getIntList
  let f xs = sum $ zipWith (*) xs (map (2^) [0..])
  a0 <- f <$> getIntList
  xyz <- replicateM m $ do
    [x, y, z] <- getIntList
    return [x-1, y-1, z-1]

  let edge = V.create $ do
        vec <- VM.replicate (2^n) IS.empty
        forM_ [0..2^n-1] $ \i -> do
          let s = foldl' (flip IS.insert) IS.empty $ map (foldl' B.complementBit i) xyz
          VM.write vec i s
        return vec

  let l = 2^n

  let result = VU.create $ do
        vec <- VUM.replicate l (-1 :: Int)
        VUM.write vec a0 0
        let go set Sq.Empty = return ()
            go set (q Sq.:<| qs) = do
              let next = IS.intersection set $ edge V.! q
              let next' =IS.toList next
              let set' = IS.difference set next
              k <- VUM.read vec q
              forM_ next' $ \j -> VUM.write vec j (k+1)
              go set' $ (Sq.><) qs (Sq.fromList next')
        go (IS.fromList ([0..a0-1] ++ [a0+1..l-1])) (Sq.singleton a0)
        return vec

  print $ result VU.! (l-1)
