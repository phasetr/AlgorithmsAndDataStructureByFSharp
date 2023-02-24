-- https://atcoder.jp/contests/tessoku-book/submissions/35574831
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = BS.getLine >>= mapM_ putStrLn . tbb51

tbb51 :: BS.ByteString -> [String]
tbb51 = loop 1 [] . BS.unpack

loop :: (Enum a, Show a) => a -> [a] -> [Char] -> [String]
loop i stack ('(':bs) = loop (succ i) (i:stack) bs
loop j (i:stack) (')':bs) = unwords [show i, show j] : loop (succ j) stack bs
loop _ _ [] = []
loop _ _ _ = error "not come here"
