-- https://atcoder.jp/contests/tessoku-book/submissions/35574572
import Control.Monad ( foldM_ )
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [q] <- bsGetLnInts
  foldM_ (\stack _ -> do
    li <- BS.getLine
    case BS.index li 0 of
      '1' -> return (BS.tail (BS.tail li) : stack)
      '2' -> BS.putStrLn (head stack) >> return stack
      _ -> return (tail stack)
    ) [] [1..q]

bsGetLnInts :: IO [Int]
bsGetLnInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
