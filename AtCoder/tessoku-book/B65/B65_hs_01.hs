-- https://atcoder.jp/contests/tessoku-book/submissions/35593991
import Control.Monad ( forM_, forM, replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn )
import Data.Ord ( Down(Down) )
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.IntSet as IS
import qualified Data.Sequence as Sq

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, t] <- getIntList
  ab <- replicateM (n-1) $ do
    [a, b] <- getIntList
    return (a-1, b-1)
  let edge = V.create $ do
          vec <- VM.replicate n (IS.empty)
          forM_ ab $ \(x, y) -> do
              VM.modify vec (IS.insert x) y
              VM.modify vec (IS.insert y) x
          return vec
  let dist = VU.create $ do
          vec <- VUM.replicate n (-1 :: Int)
          VUM.write vec (t-1) 0
          let go set Sq.Empty = return ()
              go set (q Sq.:<| qs) = do
                  let next = IS.intersection set $ edge V.! q
                      next' = IS.toList next
                      set' = IS.difference set next
                  k <- VUM.read vec q
                  forM_ next' $ \j -> VUM.write vec j (k+1)
                  go set' $ (Sq.><) qs (Sq.fromList next')
          go (IS.fromList (filter (/= (t-1)) [0..n-1])) (Sq.singleton (t-1))
          return vec
  let dsorted = map snd . sortOn Down $ zip (VU.toList dist) [0..]

  let rank = VU.create $ do
          vec <- VUM.replicate n (-1 :: Int)
          forM_ dsorted $ \i -> do
              let chokuzoku = IS.toList $ edge V.! i
              ranks <- forM chokuzoku $ \j -> VUM.read vec j
              VUM.write vec i $ (maximum ranks) + 1
          return vec
  putStrLn . unwords . map show $ VU.toList rank
