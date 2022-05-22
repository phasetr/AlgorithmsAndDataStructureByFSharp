-- https://atcoder.jp/contests/dp/submissions/19669753
import Control.Monad.State.Strict
import Data.Bool
import qualified Data.ByteString.Char8 as C
import Data.Coerce
import Data.List
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import Data.Vector.Generic ((!))

main = getl >>= \[n,m] -> getn m >>= print . solve (n+1)
getl = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine
getn t = V.unfoldrN t (runStateT $ (,) <$> geti <*> geti) <$> C.getContents
geti = coerce $ C.readInt . C.dropWhile (<'+') :: StateT C.ByteString Maybe Int

solve n es = V.maximum v where
  g = V.unsafeAccumulate U.snoc (V.replicate n U.empty) es
  v = V.generate n (\i -> bool (1+U.maximum (U.map (v!) (g!i))) 0 (U.null $ g!i)) :: V.Vector Int
