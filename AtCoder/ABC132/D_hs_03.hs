-- https://atcoder.jp/contests/abc132/submissions/6181107
import qualified Data.Text as T
import qualified Data.Text.IO as T
import qualified Data.Text.Read as T
import Data.List (unfoldr)

main :: IO ()
main = do
  (n : k : _) <- map unsafeSignedDecimal . T.words <$> T.getLine :: IO [Integer]
  let
    as = unfoldr next (1, n - k + 1)
    next (i, a) = Just (a, (succ i, (a * (n - k + 1 - i) * (k - i)) `div` ((i + 1) * i)))
  mapM_ (print . (`mod` modulus)) (take (fromInteger k) as)
  where modulus = 10 ^ 9 + 7

unsafeSignedDecimal :: T.Text -> Integer
unsafeSignedDecimal s = case T.signed T.decimal s of
  Right (n, _) -> n
  _fail -> error "not come here"
