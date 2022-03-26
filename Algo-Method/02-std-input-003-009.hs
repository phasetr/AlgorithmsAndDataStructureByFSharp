{-
https://algo-method.com/tasks/58
-}
import Control.Monad (replicateM)
main :: IO ()
main = (getLine >>= (`replicateM` getLine) . read)
  >>= putStr . map head
