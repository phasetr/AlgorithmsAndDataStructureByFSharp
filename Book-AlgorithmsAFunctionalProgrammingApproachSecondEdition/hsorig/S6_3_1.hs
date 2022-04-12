module S6_3_1 where
-- Selection Sort
import Data.List ( delete )
import qualified Sort as S

-- | P.118, naive implementation
-- For more efficient implementation, see ssort in Sort.hs
ssort :: (Ord a) => [a] -> [a]
ssort [] = []
ssort xs = m : ssort (delete m xs) where m = minimum xs

main = print $ ssort ex == [1, 1, 2, 3, 4, 5, 8, 9]
  && ssort ex == S.ssort ex
  where ex = [3,1,4,1,5,9,2,8]
