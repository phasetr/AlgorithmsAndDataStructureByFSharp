-- https://atcoder.jp/contests/abc088/submissions/10074261
import Control.Monad ( replicateM )
import qualified Data.Set as S
import qualified Data.ByteString.Char8 as BS
main :: IO ()
main = do
 [h,w] <- map read . words <$> getLine
 s <- replicateM h (BS.unpack <$> BS.getLine)
 print ((\n-> if n<0 then n else (h*w) - black s 0 - n) (wfs h w s [(1,1,1)] (S.insert (1,1) S.empty))) where
   black [] i = i
   black (t:s) i = black s (i + length (filter (=='#') t))
   wfs _ _ _ [] _ = -1
   wfs h w s ((x,y,i):q) ac
     | x==h && y==w = i
     | x>h || x<1 || y>w || y<1 = wfs h w s q ac
     | ((s!!(x-1))!!(y-1))=='#' = wfs h w s q ac
     | otherwise  = wfs h w s (push x y (i+1) q ac) (ins ac x y)
   ins ac x y = S.union ac (S.fromList [(x-1,y),(x,y-1),(x,y+1),(x+1,y)])
   push x y i q ac = q++[uo (x-1) y i ac, uo x (y-1) i ac, uo x (y+1) i ac, uo (x+1) y i ac]
   uo x y i ac = if S.member (x,y) ac then (0,0,0) else (x,y,i)
