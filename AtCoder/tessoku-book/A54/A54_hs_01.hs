-- https://atcoder.jp/contests/tessoku-book/submissions/35596167
import Control.Monad ( foldM_ )
import qualified Data.Map as M

main :: IO ()
main = do
  q <- readLn
  foldM_ (\m _ -> do
    li <- getLine
    case words li of
      "1":x:y:_ -> return $ M.insert x (read y :: Int) m
      "2":x:_   -> print (m M.! x) >> return m
      _err -> error "not come here"
    ) M.empty [1..q]
