-- https://atcoder.jp/contests/abc125/submissions/30751167
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.Functor ( (<&>) )
import Data.List ( unfoldr )

main :: IO ()
main = do
  [n] <- bsGetLnInts
  as <- bsGetLnInts
  let ans = abc125d n as
  print ans

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

abc125d :: Int -> [Int] -> Int
abc125d n (a:as) = loop a (negate a) as
abc125d _ _ = error "not come here"

loop :: (Ord t, Num t) => t -> t -> [t] -> t
loop accP accM [a] = max (accP + a) (accM - a)
loop accP accM (a:as) = loop (max (accP + a) (accM - a)) (max (accM + a) (accP - a)) as
loop _ _ _ = error "not come here"
