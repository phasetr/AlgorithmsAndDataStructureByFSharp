-- https://atcoder.jp/contests/tessoku-book/submissions/35596517
import Control.Monad ( foldM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )
import qualified Data.IntSet as IS

main :: IO ()
main = do
  [q] <- bsGetLnInts
  foldM_ (\s _ -> do
    qi <- bsGetLnInts
    case qi of
      1:x:_ -> return $ IS.insert x s
      2:x:_ -> print (tbb55 x s) >> return s
      _e -> error "not come here"
    ) IS.empty [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbb55 :: Int -> IS.IntSet -> Int
tbb55 x s =
  case (IS.lookupLE x s, IS.lookupGT x s) of
    (Nothing, Nothing) -> -1
    (c1     , c2     ) -> min (mm (x -) c1) (mm (subtract x) c2)
  where mm = maybe maxBound
