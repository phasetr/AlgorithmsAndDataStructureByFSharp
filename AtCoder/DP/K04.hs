-- https://atcoder.jp/contests/dp/submissions/19761888
import Data.Array ( Ix, (!), array )
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )

main :: IO ()
main = get >>= putStrLn . solve where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve :: (Enum i, Ix i, Num i) => [i] -> [Char]
solve (n:k:as) = bool "Second" "First" $ g!k where
  g = array (0,k) $ (0,False):[(i,e) | i <- [1..k],
                                let e = not . all ((g!) . (i -)) $ filter (<=i) as]
solve _ = undefined
