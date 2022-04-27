-- https://atcoder.jp/contests/dp/submissions/19874849
import Data.Array ( Ix, (!), array )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )

main :: IO ()
main = get >>= print . solve where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve :: (Ix p, Enum p, Num p) => [p] -> p
solve (n:as) = a!(1,n) where
  a = array ((1,1),(n,n))
      $ zipWith (\i x -> ((i,i),x)) [1..] as ++
      [((i,j),max (a!(i,i)-a!(i+1,j)) (a!(j,j)-a!(i,j-1))) |
        k <- [1..n-1],
        i <- [1..n-k], let j=k+i]
solve _ = undefined
