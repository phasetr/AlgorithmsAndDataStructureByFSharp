-- https://atcoder.jp/contests/tessoku-book/submissions/35649772
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [n,l,r] <- bsGetLnInts
  xs <- bsGetLnInts
  let ans = tbb58 n l r xs
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

tbb58 :: p -> Int -> Int -> [Int] -> Int
tbb58 n l r xs = get xn (succ xn) t where
  t = head $ until singleton (map merge1 . chunksOf 2) $ map single $ map f xs
  f x = if x == x1 then (x, 0) else (x, succ $ get (x - r) (x - l + 1) t)
  xn = last xs
  x1 = head xs

tooBig :: Int
tooBig = div maxBound 2

data Tree = Leaf | Node Int Int Int Tree Tree -- 下限、上限、値、左右の子

single :: (Int, Int) -> Tree
single (x, v) = Node x (succ x) v Leaf Leaf

chunksOf :: Int -> [a] -> [[a]]
chunksOf _ [] = []
chunksOf n xs = let (as,bs) = splitAt n xs in as : chunksOf n bs

merge1 :: [Tree] -> Tree
merge1 [l@(Node lb1 _ x1 _ _), r@(Node _ ub2 x2 _ _)] = Node lb1 ub2 (min x1 x2) l r
merge1 [t] = t
merge1 _ = error "not come here"

singleton :: [a] -> Bool
singleton xs = not (null xs) && null (tail xs)

get :: Int -> Int -> Tree -> Int
get l r = loop where
  loop (Node lb ub x lt rt)
    | l <= lb && ub <= r = x
    | r <= lb || ub <= l = tooBig
    | otherwise = min (loop lt) (loop rt)
  loop _ = error "not come here"
