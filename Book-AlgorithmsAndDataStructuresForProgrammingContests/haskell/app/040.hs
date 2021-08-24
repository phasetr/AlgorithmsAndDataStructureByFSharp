module Main where

import Data.List

lst = [25, 36, 4, 55, 71, 18, 0, 71, 89, 65]

main :: IO ()
main = print $ take 3 $ reverse $ sort lst
