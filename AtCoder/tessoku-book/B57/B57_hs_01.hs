-- https://atcoder.jp/contests/tessoku-book/submissions/35628917
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )
import qualified Data.Vector.Unboxed as UV

main :: IO ()
main = do
  [n,k] <- getLnInts
  let ans = tbb57 n k
  mapM_ print ans

getLnInts :: IO [Int]
getLnInts = getLine <&> map read . words

tbb57 :: Int -> Int -> [Int]
tbb57 n k = [x | i <- 1 : [10,20..n], let x = g i, _ <- [i..min (div i 10 * 10 + 9) n]] where
  vs = iterate twice $ UV.fromList $ map f [0,10..n]
  f x = x - sum (unfoldr step x)
  step 0 = Nothing
  step x = let (q,r) = divMod x 10 in Just (r, q)
  twice av = UV.fromList $ map ((av UV.!) . flip div 10 . (av UV.!) . flip div 10) [0,10..n]
  bs = map odd $ takeWhile (0 <) $ iterate (flip div 2) k
  g x = foldl (flip (UV.!) . flip div 10) x [v | (True, v) <- zip bs vs]
