-- https://atcoder.jp/contests/abc113/submissions/9697097
import qualified Data.ByteString.Char8 as BS
import Data.List ( sort )
import Control.Monad ( replicateM )
main :: IO ()
main = do
  [n,m] <- map read.words <$> getLine
  py <- replicateM m (map (read.BS.unpack).BS.words <$> BS.getLine)
  mapM_ putStrLn (h m (sort(g m 0 0 (sort(f m m py))))) where
    f _ 0 l =[]
    f m n (x:l) =(x++[m-n]):f m (n-1) l
    f _ _ _ = error "not come here"
    g 0 _ _ pyi =[]
    g m j n ([p,y,i]:pyi) |p==j =[i,p,n+1]:g (m-1) j (n+1) pyi
                          |p>j  =[i,p,1]:g (m-1) p 1 pyi
    g _ _ _ _ = error "not come here"
    h 0 ipy =[]
    h m ([i,p,y]:ipy) =(k(show p)++k(show y)):h (m-1) ipy
    h _ _ = error "not come here"
    k n = replicate (6 - length n) '0' ++n
