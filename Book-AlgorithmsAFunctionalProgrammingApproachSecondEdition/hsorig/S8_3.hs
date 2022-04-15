module S8_3 where
import Data.Array ( (!) )
import Search ( g8T, goal8Tile, mandist, s8T, succ8Tile, Board, Boards(..), Position, searchPfs )

-- P.168 Section 8.3.2
-- | P.169
heur1 :: Board  -> Int
heur1 b = sum [mandist (b!i) (g8T!i) | i<-[0..8]]

-- | P.169
-- Need to define equality of Boards in the priority queue
-- before defining order
-- instance Eq Boards where BDS(b1:_) == BDS(b2:_) = heur1 b1 == heur1 b2
instance Ord Boards where BDS (b1:_) <= BDS (b2:_) = heur1 b1 <= heur1 b2

-- | P.169 second heuristic
outseq   :: Board -> Int
outseq b = sum [score (b!i) (b!(i+1)) | i <- [1..7]] + score (b!8) (b!1)
-- | P.170 second heuristic
heur2 :: Board -> Int
heur2 b = heur1 b + 3 * outseq b
-- | P.170 second heuristic
score :: Position -> Position -> Int
score (2,2) _      = 1
score (1,3) (2,3)  = 0
score (2,3) (3,3)  = 0
score (3,3) (3,2)  = 0
score (3,2) (3,1)  = 0
score (3,1) (2,1)  = 0
score (2,1) (1,1)  = 0
score (1,1) (1,2)  = 0
score (1,2) (1,3)  = 0
score _ _          = 2

{--
-- Need to define equality of Boards in the priority queue
--  before defining order
instance Eq Boards where BDS(b1:_) == BDS(b2:_) = heur2 b1 == heur2 b2

instance Ord Boards
  where BDS (b1:_) <  BDS (b2:_) = heur2 b1 <  heur2 b2
        BDS (b1:_) <= BDS (b2:_) = heur2 b1 <= heur2 b2
--}
-- stats = (length ls, t) where ((BDS ls,t):_) = searchPfs succ8Tile goal8Tile (BDS [s8T])
