-- https://atcoder.jp/contests/abc094/submissions/20096538
import qualified Data.ByteString.Char8 as BS
import Data.Maybe ( fromJust )
import Data.Function ( on )
import Data.List ( minimumBy )

readInt :: BS.ByteString -> Int
readInt = fst . fromJust . BS.readInt

main = do
  n <- read <$> getLine
  as <- map readInt . BS.words <$> BS.getLine
  let r = solve n as
  putStrLn $ show (fst r) ++ " " ++ show (snd r)

solve :: Int -> [Int] -> (Int, Int)
solve n as = let (b, _) = minimumBy (compare `on` snd) $ map (\a -> (a, abs (a - mx `div` 2))) $ filter (/= mx) as in (mx, b)
  where mx = maximum as
