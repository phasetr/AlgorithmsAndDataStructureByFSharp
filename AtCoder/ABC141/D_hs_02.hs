-- https://atcoder.jp/contests/abc141/submissions/10296680
import qualified Data.Set as S
import qualified Data.ByteString.Char8 as BS
main :: IO ()
main = do
 [n,m]<-map read.words<$>getLine
 a<-map (read.BS.unpack).BS.words<$>BS.getLine
 print(f m (S.fromList (zip a [1..n]))) where
   f 0 s = sum(map fst (S.toList s))
   f m s = f (m-1) (S.insert((\(a,i)->(quot a 2,i))(S.findMax s))(S.deleteMax s))
