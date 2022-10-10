-- https://atcoder.jp/contests/agc043/submissions/14403317
import Data.Array
main = do
  [h,w] <- map read . words <$> getLine
  grid <- array ((1,1),(h,w)) . zip [(i,j)|i <- [1..h], j <- [1..w]] . concat . lines <$> getContents
  let ans = array ((1,1),(h,w)) [((i,j), f grid i j)| i <- [1..h], j <- [1..w]] where
        f :: Array (Int,Int) Char -> Int -> Int -> Int
        f g 1 1 = if g ! (1,1) == '#' then 1 else 0
        f g i j = min di dj where
          cij = g ! (i,j)
          ci1j = if i >= 2 then g ! (i-1,j) else cij
          cij1 = if j >= 2 then g ! (i,j-1) else cij
          di1j = if i >= 2 then ans ! (i-1,j) else 200
          dij1 = if j >= 2 then ans ! (i,j-1) else 200
          di = if ci1j == '.' && cij == '#' then di1j + 1 else di1j
          dj = if cij1 == '.' && cij == '#' then dij1 + 1 else dij1
  print $ ans ! (h,w)
