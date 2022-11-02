-- https://atcoder.jp/contests/abc110/submissions/23916699
import qualified Data.ByteString.Char8 as C
import Data.List ( sort )

main :: IO ()
main = do
  s <- C.getLine
  t <- C.getLine
  putStrLn $ if isSatisfied s t then "Yes" else "No"

isSatisfied :: C.ByteString -> C.ByteString -> Bool
isSatisfied s t = freq s == freq t
  where freq x = sort $ map C.length $ C.group $ C.sort x
