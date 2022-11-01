-- https://atcoder.jp/contests/abc113/submissions/22769268
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( groupBy, sort, sortBy, unfoldr )
import Data.Function ( on )

main :: IO ()
main = do
  BS.getLine
  co <- BS.getContents
  let pys = map (l2p . unfoldr (BS.readInt . BS.dropWhile isSpace)) $ BS.lines co
  let ans = compute pys
  mapM_ putStrLn ans

l2p :: [b] -> (b, b)
l2p [a,b] = (a,b)
l2p _ = error "not come here"

compute :: [(Int,Int)] -> [String]
compute pys = map snd ipxs where
  pyis = sortBy (compare `on` fst) $ zip pys [1..]
  pyiss = groupBy ((==) `on` (fst . fst)) pyis
  ipxs = sort $ concatMap (zipWith y2x [1..]) pyiss
  y2x x ((p,_),i) = (i,tail $ show $ (1000000 + p) * 1000000 + x)
