{-
https://atcoder.jp/contests/abc118/submissions/21492146
-}
import Data.Maybe(fromJust)
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = do
  [n] <- readLnInt
  inputs <- readLnInt
  print $ solve inputs where
    readLnInt = map (fst . fromJust . C.readInt) . C.words <$> C.getLine

solve :: [Int] -> Int
solve (a:x) = VU.foldl gcd a $ VU.fromList x
solve _ = undefined
