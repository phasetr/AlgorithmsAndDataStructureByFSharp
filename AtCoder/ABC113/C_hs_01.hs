-- https://atcoder.jp/contests/abc113/submissions/14694387
import Text.Printf ( printf )
import Data.List ( groupBy, sort )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as IM
import qualified Data.Set as S
main :: IO ()
main = mapM_ putStrLn . solve . map ((\[a,b]->(a,b)).map(fst.fromJust.B.readInt).B.words).B.lines=<<B.getContents

solve :: [(Int, Int)] -> [String]
solve ((n,m):pys)  =map(\(p,y)->concatMap(printf"%06d")[p,S.findIndex y(m IM.! p)+1])pys where
  m=foldr(\gs m->IM.insert(fst$head gs)(S.fromList$map snd gs)m)IM.empty.groupBy(\a b->fst a==fst b).sort$pys
solve _ = error "not come here"
