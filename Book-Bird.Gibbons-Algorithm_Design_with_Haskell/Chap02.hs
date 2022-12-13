module Chap02 where
import           Prelude                 hiding ( concat )
{-# ANN concat1 "HLint: ignore" #-}
concat1 :: [[a]] -> [a]
concat1 = foldr (++) []
{-# ANN concat2 "HLint: ignore" #-}
concat2 :: [[a]] -> [a]
concat2 = foldl (++) []
inserts :: a -> [a] -> [[a]]
inserts = help id
help :: ([a] -> b) -> a -> [a] -> [b]
help f x []       = [f [x]]
help f x (y : ys) = f (x : y : ys) : help (f . (y :)) x ys
-- P.33 2.3 Running times in context
-- 10001 == (Prelude.length $ Chap01.tails [1..10000])
-- 10001 == (Prelude.length $ Chap01.inits [1..10000])
-- Chap01.inits "abcd" == ["", "a", "ab", "abc", "abcd"]
-- Chap01.tails "abcd" == ["abcd", "bcd", "cd", "d", ""]
-- help id 1 [2,3] == [[1,2,3], [2,1,3], [2,3,1]]
-- P.34 2.4 Amortised running times
build :: (a -> a -> Bool) -> [a] -> [a]
build p = foldr insert [] where insert x xs = x : dropWhile (p x) xs
-- build (==) [4,4,2,1,1,1,2,5] == [4,2,1,2,5]
type Bit = Int
bits :: Int -> [[Bit]]
bits n = take n (iterate inc [])
 where
  inc []       = [1]
  inc (0 : bs) = 1 : bs
  inc (1 : bs) = 0 : bs
  inc _        = error "should not come here"
-- bits 10
prune :: ([a] -> Bool) -> [a] -> [a]
prune p = foldr cut []
 where
  cut x xs = until done init (x : xs)
  done xs = null xs || p xs
-- prune ordered [3,7,8,23]
-- Chapter notes
-- http://stackoverflow.com/questions/24484348/
-- Answer 2.9
op1 :: [p] -> p -> p
op1 xs y = if null xs then y else head xs
test1 :: Bool
test1 = head (xs ++ ys) == op1 xs (head ys)
 where
  xs = [1, 2, 3]
  ys = [4, 5, 6]
-- test1
test2 :: Bool
test2 = head (concat1 xs) == foldr op1 undefined xs
  where xs = [[1, 2], [3, 4]]
-- Answer 2.12
-- linear time inits
inits :: [a] -> [[a]]
inits = help id
 where
  help f []       = [f []]
  help f (x : xs) = f [] : help (f . (x :)) xs
-- Chap02.inits "abcd"
-- Chap01 版は時間がかかる
-- 5001 == (Prelude.length $ Chap01.inits [1..5000])
-- Chap02 版で時間が短くなるか確認
-- 50001 == (Prelude.length $ Chap02.inits [1..50000])
-- Answer 2.14
tails1 :: [a] -> [[a]]
tails1 = takeWhile (not . null) . iterate tail
-- tails1 "abcd"
-- 所要時間測定
-- 50000 == (Prelude.length $ Chap02.tails1 [1..50000])
-- P.63, Chap03
-- reverse を使っているため online algorithm には使えない
inits' :: [a] -> [[a]]
inits' = map reverse . reverse . tails1 . reverse
