{-
https://algo-method.com/tasks/61
-}
module Main where
import Control.Monad (replicateM)
import Data.Function ((&))
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = getLine >> getLine >>= print . minimum . map (\x -> read x :: Int) . words
