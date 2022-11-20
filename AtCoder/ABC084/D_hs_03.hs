-- https://atcoder.jp/contests/abc084/submissions/7958168
import qualified Data.ByteString.Char8 as BS
import Data.Maybe ( fromJust )
import Data.Array.IArray ( Array, (!), listArray )

isPrime :: Integral a => a -> Bool
isPrime n
  | n <= 2    = n == 2
  | otherwise = odd n && f 3
  where
    f i
      | i^2 > n   = True
      | otherwise = n `rem` i /= 0 && f (i+2)

primesArray :: Int -> Array Int Bool
primesArray n = listArray (0,n) $ map isPrime [0..n]

main :: IO ()
main = do
  _ <- getLine
  lr <- map ((\[a,b] -> (a,b))
      . map (fst . fromJust . BS.readInt) . BS.words) . BS.lines
      <$> BS.getContents :: IO [(Int,Int)]
  let m = 10^5
      p = primesArray m
      f n = p!n && p!((n+1) `div` 2)
      c = listArray (0,m)
              $ scanl (\a i -> if f i then a+1 else a)
              0 [1..m] :: Array Int Int
      solve l r = (c!r) - (c!(l-1))
  mapM_ (print . uncurry solve) lr
