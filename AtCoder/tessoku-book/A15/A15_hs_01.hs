-- https://atcoder.jp/contests/tessoku-book/submissions/37385232
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.Set as S

main :: IO ()
main = (C.getLine *> get) >>= put . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

put :: [Int] -> IO ()
put = putStrLn . unwords . fmap show

sol :: Ord a => [a] -> [Int]
sol as = map (succ . flip S.findIndex s) as
  where s = S.fromList as
