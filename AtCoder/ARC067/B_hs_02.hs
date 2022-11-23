-- https://atcoder.jp/contests/abc052/submissions/11073119
import qualified Data.ByteString.Char8  as C
import Data.List ( unfoldr )

main :: IO ()
main = get >>= print . sol

get :: IO [[Int]]
get = fmap (unfoldr (C.readInt . C.dropWhile (==' '))) . C.lines <$> C.getContents
sol :: (Num c, Ord c) => [[c]] -> c
sol [[_,a,b],xs] = sum . fmap (min b . (*a)) $ zipWith (-) (tail xs) xs
sol _ = error "not come here"
