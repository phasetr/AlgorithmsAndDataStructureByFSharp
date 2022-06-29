module HoodMelvilleQueue (HoodMelvilleQueue) where
  import Prelude hiding (head,tail)
  import Queue

  data RotationState a =
    Idle
    | Reversing Int [a] [a] [a] [a]
    | Appending Int [a] [a]
    | Done [a]

  data HoodMelvilleQueue a = HM Int [a] (RotationState a) Int [a]

  exec (Reversing ok (x:xs) fs (y : ys) z) = Reversing (ok+1) xs (x : fs) ys (y : z)
  exec (Reversing ok [ ] fs [y] z) = Appending ok fs (y : z)
  exec (Appending 0 f r) = Done r
  exec (Appending ok (x : f) r) = Appending (ok-1) f (x : r)
  exec state = state

  invalidate (Reversing ok f g r q) = Reversing (ok-1) f g r q
  invalidate (Appending 0 f (x : r)) = Done r
  invalidate (Appending ok g q) = Appending (ok-1) g q
  invalidate state = state

  exec2 lenf f state lenr r =
    case exec (exec state) of
      Done newf -> HM lenf newf Idle lenr r
      newstate -> HM lenf f newstate lenr r
  check lenf f state lenr r =
    if lenr <= lenf then exec2 lenf f state lenr r
    else let newstate = Reversing 0 f [ ] r [ ]
      in exec2 (lenf+lenr) f newstate 0 [ ]

  instance Queue HoodMelvilleQueue where
    empty = HM 0 [ ] Idle 0 [ ]
    isEmpty (HM lenf f state lenr r) = lenf == 0

    snoc (HM lenf f state lenr r) x = check lenf f state (lenr+1) (x : r)

    head (HM _ [ ] _ _ _ ) = error "empty queue"
    head (HM _ (x : xs) _ _ _ ) = x

    tail (HM lenf [ ] state lenr r) = error "empty queue"
    tail (HM lenf (x : xs) state lenr r) =
      check (lenf-1) xs (invalidate state) lenr r
