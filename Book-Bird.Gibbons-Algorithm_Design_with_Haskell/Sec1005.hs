-- P.272 10.5 A general thinning algorithm
module Sec1005 where
{-
-- anon: some initial candidate.
candidates :: [Data] -> [Candidate]
candidates = foldr (concatMap・extend) [anon]

best :: [Data] -> Candidate
best <- MinWith cost . filter good . candidates

-- P.256
step d = concatMap (filter good ・extend d)

-- P.256
best = minWith cost . foldr step [anon]
  where step d = thinBy (≼)・concatMap (filter good ・extend d)

-- P.256
best = minWith cost . foldr step [anon]
  where
    step d = thinBy (≼) . mergeBy cmp . map (filter good . extend d)
    cmp x y = value x ≼ value y
-}
