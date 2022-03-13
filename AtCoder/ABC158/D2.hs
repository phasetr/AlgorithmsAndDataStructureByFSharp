{-
https://atcoder.jp/contests/abc158/submissions/28616340
-}
import qualified Data.ByteString.Char8 as BS
import Data.Sequence ((<|),fromList,(|>),Seq)
import qualified Data.Sequence as S
import Data.Foldable (toList)

solve :: Int -> Seq Char -> Bool -> IO String
solve 0 s r = return . toList $ if r then S.reverse s else s
solve i s r = do
  qq <- words <$> getLine :: IO [String]
  case qq of
    ["1"] -> solve (i-1) s (not r)
    ["2",f,c] -> do
      let s' | not r     = if f == "1" then head c <| s else s |> head c
             | otherwise = if f == "1" then s |> head c else head c <| s
      solve (i-1) s' r
    _ -> undefined

main :: IO ()
main = do
  s <- BS.unpack <$> BS.getLine :: IO String
  q <- readLn :: IO Int
  putStrLn =<< solve q (fromList s) False
