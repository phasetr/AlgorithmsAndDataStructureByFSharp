-- https://atcoder.jp/contests/tessoku-book/submissions/37572893
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', scanl' )

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Char]
get = C.unpack . C.filter (>'+') <$> C.getLine

sol :: Eq a => [a] -> [a] -> Int
sol s t = last $ foldl' f [0..length t] $ zip s [1..] where
  f u (a,i) = scanl' (g a) i $ zip3 t u (tail u)
  g a i (b,j,k) = minimum [i+1,j+bool 1 0 (a==b),k+1]
