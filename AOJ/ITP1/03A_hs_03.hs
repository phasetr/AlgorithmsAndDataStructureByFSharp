import Control.Monad ( replicateM_ )
main :: IO ()
main = replicateM_ 1000 $ putStrLn "Hello World"
