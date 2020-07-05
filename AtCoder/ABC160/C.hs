-- https://atcoder.jp/contests/abc160/submissions/11373829
import qualified Data.Vector.Unboxed as U
main :: IO ()
main = do
    [k, n] <- map read . words <$> getLine :: IO [Int]
    getLine >>= print . solve k . U.fromList . map (read :: String -> Int). words

solve :: Int -> U.Vector Int -> Int
solve k xs = (k-) . U.foldl' max (k - U.last xs + U.head xs) $ U.zipWith (-) (U.tail xs) xs
