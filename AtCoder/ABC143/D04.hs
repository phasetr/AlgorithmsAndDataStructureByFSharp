{-
https://atcoder.jp/contests/abc143/submissions/8075155
-}
-- https://github.com/minoki/my-atcoder-solutions
{-# LANGUAGE BangPatterns #-}
import Data.Char (isSpace)
import Data.List (unfoldr, tails, sort)
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM
import qualified Data.ByteString.Char8 as BS

isTriangle :: Int -> Int -> Int -> Bool
isTriangle a b c = a < b + c && b < c + a && c < a + b

naive = do
  n <- readLn :: IO Int
  xs <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  print $ length [ (a,b,c) | a:xss <- tails xs, b:xsss <- tails xss, c <- xsss, isTriangle a b c ]

-- v は昇順にソートされているとする。
-- countGE a v は a 以上の要素の個数を数える。
countGE :: Int -> U.Vector Int -> Int
countGE !a = loop 0
  where
    loop !s !v | U.null v = s
               | U.length v == 1 = if a <= U.head v then
                                     s + 1
                                   else
                                     s
               | otherwise = let n = U.length v
                                 n2 = n `quot` 2
                             in if a <= v U.! n2 then
                                  loop (n - n2 + s) (U.take n2 v)
                                else
                                  loop s (U.drop n2 v)

main = do
  n <- readLn :: IO Int
  xs <- mergeSort . U.unfoldrN n (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  let c = U.generate (2*10^3+1) $ \c_max -> countGE c_max xs
  print $ sum [ n - (j+1) - c U.! c_max
              | i <- [0..n-1]
              , let a = xs U.! i
              , j <- [i+1..n-1]
              , let b = xs U.! j
              , let c_max = a + b {- c < a + b, b - a < c, a - b < c -}
              ]

mergeSortBy :: (U.Unbox a) => (a -> a -> Ordering) -> U.Vector a -> U.Vector a
mergeSortBy !cmp !vec = doSort vec
  where
    doSort vec | U.length vec <= 1 = vec
               | otherwise = let (xs, ys) = U.splitAt (U.length vec `quot` 2) vec
                             in merge (doSort xs) (doSort ys)
    merge xs ys = U.create $ do
      let !n = U.length xs
          !m = U.length ys
      result <- UM.new (n + m)
      let loop !i !j
            | i == n = U.copy (UM.drop (i + j) result) (U.drop j ys)
            | j == m = U.copy (UM.drop (i + j) result) (U.drop i xs)
            | otherwise = let !x = xs U.! i
                              !y = ys U.! j
                          in case cmp x y of
                               LT -> do UM.write result (i + j) x
                                        loop (i + 1) j
                               EQ -> do UM.write result (i + j) x
                                        UM.write result (i + j + 1) y
                                        loop (i + 1) (j + 1)
                               GT -> do UM.write result (i + j) y
                                        loop i (j + 1)
      loop 0 0
      return result

mergeSort :: (U.Unbox a, Ord a) => U.Vector a -> U.Vector a
mergeSort = mergeSortBy compare
